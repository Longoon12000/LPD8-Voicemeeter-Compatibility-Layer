using NAudio.Midi;
using TobiasErichsen.teVirtualMIDI;

namespace MidiHandler
{
    public partial class MidiHandler : Form
    {
        TeVirtualMIDI? port;
        MidiIn? midiIn;
        MidiOut? midiOut;

        public MidiHandler()
        {
            InitializeComponent();
        }

        private class MidiDevice
        {
            internal int? InputDeviceNumber;
            internal int? OutputDeviceNumber;

            internal string? DeviceName;

#pragma warning disable CS8603 // For some reason even tho the ?? operator is used, it still complains about DeviceName being null
            public override string ToString() => this.DeviceName ?? base.ToString();
#pragma warning restore CS8603 // Possible null reference return.
        }

        private void btnEnable_Click(object sender, EventArgs e)
        {
            if (cbMidiDevices.SelectedItem is null)
            {
                MessageBox.Show($"Please select a MIDI device from the list.{Environment.NewLine}If the list is empty, then you do not have any compatible devices (requires MIDI in and out).", "No device selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            start((MidiDevice)cbMidiDevices.SelectedItem);
        }

        private void start(MidiDevice midiDevice)
        {
            try
            {
                Guid manufacturer = new Guid("a19f3afb-d808-4b7c-a9d9-b2a0af699522");
                Guid product = new Guid("cd657163-5ff1-43dc-a70d-77cc57ca2b17");

                port = new TeVirtualMIDI("Virtual LPD8VMCL", 65535, TeVirtualMIDI.TE_VM_FLAGS_PARSE_RX, ref manufacturer, ref product);
                midiIn = new MidiIn(midiDevice.InputDeviceNumber!.Value);
                midiOut = new MidiOut(midiDevice.OutputDeviceNumber!.Value);
                midiIn.Start();
                midiIn.MessageReceived += this.MidiIn_MessageReceived;
                Task.Run(handleVirtualPort);
                Task.Run(sendRepeatNoteEvents);
                File.WriteAllText("./settings", midiDevice.DeviceName);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occured during initialisation. This could be caused by the MIDI device being in use by another program.{Environment.NewLine}{ex.Message}", "Error during initialisation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            this.btnEnable.Enabled = false;
            this.cbMidiDevices.Enabled = false;
            this.Visible = false;
        }

        private void MidiIn_MessageReceived(object? sender, MidiInMessageEventArgs e)
        {
            port!.sendCommand(BitConverter.GetBytes(e.RawMessage));
        }

        private void handleVirtualPort()
        {
            while (port is not null)
            {
                try
                {
                    byte[] command = port!.getCommand();
                    byte[] rawCommand = new byte[4];
                    command.CopyTo(rawCommand, 0);

                    MidiEvent midiEvent = MidiEvent.FromRawMessage(BitConverter.ToInt32(rawCommand));
                    MidiEvent? sameTargetEvent = midiEvent switch
                    {
                        NoteEvent midiNoteEvent => repeatMidiEvents.OfType<NoteEvent>().FirstOrDefault(m => m.NoteNumber == midiNoteEvent.NoteNumber),
                        ControlChangeEvent midiControlChangeEvent => repeatMidiEvents.OfType<ControlChangeEvent>().FirstOrDefault(m => m.Controller == midiControlChangeEvent.Controller),
                        _ => null
                    };

                    if (sameTargetEvent is not null)
                    {
                        repeatMidiEvents.Remove(sameTargetEvent);
                    }
                    repeatMidiEvents.Add(midiEvent);

                    midiOut!.SendBuffer(command);
                }
                catch (Exception) { }
            }
        }

        private async void sendRepeatNoteEvents()
        {
            while (midiOut is not null)
            {
                try
                {
                    foreach (MidiEvent midiEvent in repeatMidiEvents)
                    {
                        midiOut!.Send(midiEvent.GetAsShortMessage());
                    }
                    await Task.Delay(50);
                }
                catch (Exception) { }
            }
        }

        List<MidiEvent> repeatMidiEvents = new List<MidiEvent>();

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.exit();
        }

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (port is not null)
            {
                port.shutdown();
                port = null;
            }

            if (midiIn is not null)
            {
                midiIn.Stop();
                midiIn.Close();
                midiIn = null;
            }

            if (midiOut is not null)
            {
                midiOut.Close();
                midiOut = null;
            }

            this.cbMidiDevices.Enabled = true;
            this.btnEnable.Enabled = true;
            this.Visible = true;
            File.Delete("./settings");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.exit();
        }

        private void exit()
        {
            Application.Exit();
        }

        private void MidiHandler_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                this.Visible = false;
                e.Cancel = true;
            }
        }

        private void MidiHandler_Shown(object sender, EventArgs e)
        {
            List<MidiDevice> midiDevices = new List<MidiDevice>();
            for (int deviceNumber = 0; deviceNumber < MidiIn.NumberOfDevices; deviceNumber++)
            {
                midiDevices.Add(new MidiDevice()
                {
                    InputDeviceNumber = deviceNumber,
                    DeviceName = MidiIn.DeviceInfo(deviceNumber).ProductName
                });
            }

            for (int deviceNumber = 0; deviceNumber < MidiOut.NumberOfDevices; deviceNumber++)
            {
                string deviceName = MidiOut.DeviceInfo(deviceNumber).ProductName;
                MidiDevice? midiDevice = midiDevices.FirstOrDefault(d => d.DeviceName == deviceName);
                if (midiDevice is not null)
                {
                    midiDevice.OutputDeviceNumber = deviceNumber;
                }
            }

            this.cbMidiDevices.Items.AddRange(midiDevices.Where(d => d.InputDeviceNumber is not null && d.OutputDeviceNumber is not null).Select(d => (object)d).ToArray());

            if (File.Exists("./settings"))
            {
                string deviceName = File.ReadAllText("./settings");
                MidiDevice? midiDevice = midiDevices.FirstOrDefault(d => d.DeviceName == deviceName);
                if (midiDevice is null)
                {
                    MessageBox.Show($"Could not find MIDI device with name \"{deviceName}\".", "Failed to load MIDI device", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                start(midiDevice);
            }
        }
    }
}
