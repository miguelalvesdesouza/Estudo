using Opc.Ua;
using Opc.Ua.Client;
using Opc.Ua.Client.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestConnectOPCUA
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public Opc.Ua.Client.Controls.ConnectServerCtrl connectServerCtrl1;

        private void Form2_Load(object sender, EventArgs e)
        {
            if (this.connectServerCtrl1 !=null)
            {
                
                createSubscriptMonitor();
            }
        }
        Subscription m_subscription;
        void createSubscriptMonitor()
        {
            try
            {
                Session m_session = this.connectServerCtrl1.Session;
                if (m_session == null)
                {
                    return;
                }

                if (m_subscription != null)
                {
                    m_session.RemoveSubscription(m_subscription);
                    m_subscription = null;
                }

                m_subscription = new Subscription();
                m_subscription.PublishingEnabled = true;
                m_subscription.PublishingInterval = 100;
                m_subscription.Priority = 1;
                m_subscription.KeepAliveCount = 10;
                m_subscription.LifetimeCount = 20;
                m_subscription.MaxNotificationsPerPublish = 1000;

                m_session.AddSubscription(m_subscription);
                m_subscription.Create();


                MonitoredItem monitoredItem2 = new MonitoredItem();
                monitoredItem2.StartNodeId = new NodeId("Simulation Examples.Functions.Random2", 2);
                monitoredItem2.AttributeId = Attributes.Value;
                monitoredItem2.Notification += MonitoredItem2_Notification;
                m_subscription.AddItem(monitoredItem2);




                //Method 3:

                MonitoredItem monitoredItem3 = new MonitoredItem();
                monitoredItem3.StartNodeId = new NodeId("Channel1.Device1.v1", 2);
                monitoredItem3.AttributeId = Attributes.Value;
                monitoredItem3.Notification += MonitoredItem3_Notification;
                m_subscription.AddItem(monitoredItem3);
                tagLedWrite = monitoredItem3;//to write later

                MonitoredItem monitoredItem4 = new MonitoredItem();
                monitoredItem4.StartNodeId = new NodeId("Simulation Examples.Functions.Random2", 2);
                monitoredItem4.AttributeId = Attributes.Value;
                monitoredItem4.Notification += MonitoredItem4_Notification;
                m_subscription.AddItem(monitoredItem4);

                m_subscription.ApplyChanges();
            }
            catch (Exception exception)
            {
                ClientUtils.HandleException(this.Text, exception);
            }
        }

        private void MonitoredItem2_Notification(MonitoredItem monitoredItem, MonitoredItemNotificationEventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new MonitoredItemNotificationEventHandler(MonitoredItem2_Notification), monitoredItem, e);
                return;
            }
            try
            {
                this.lbAnalogMeter1.Value = double.Parse(((MonitoredItemNotification)e.NotificationValue).Value.WrappedValue.ToString());
            }
            catch
            { }
        }

        private void MonitoredItem4_Notification(MonitoredItem monitoredItem, MonitoredItemNotificationEventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new MonitoredItemNotificationEventHandler(MonitoredItem4_Notification), monitoredItem, e);
                return;
            }
            try
            {
                this.label1.Text = ((MonitoredItemNotification)e.NotificationValue).Value.WrappedValue.Value.ToString();
            }
            catch (Exception ex)
            {
                ClientUtils.HandleException(this.Text, ex);
            }
        }

        private void MonitoredItem3_Notification(MonitoredItem monitoredItem, MonitoredItemNotificationEventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new MonitoredItemNotificationEventHandler(MonitoredItem3_Notification), monitoredItem, e);
                return;
            }
            try
            {
                if ((bool)((MonitoredItemNotification)e.NotificationValue).Value.WrappedValue.Value == false)
                {
                    this.lbLed1.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off;
                    this.pictureBox1.Image = global::TestConnectOPCUA.Properties.Resources.stop;
                }
                else
                {
                    this.lbLed1.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On;
                    this.pictureBox1.Image = global::TestConnectOPCUA.Properties.Resources.nut_dang_ky;
                }
            }
            catch (Exception ex)
            {
                ClientUtils.HandleException(this.Text, ex);
            }
        }

        MonitoredItem tagLedWrite;
        private void lbButton1_MouseDown(object sender, MouseEventArgs e)
        {
            this.lbButton1.State = LBSoft.IndustrialCtrls.Buttons.LBButton.ButtonState.Pressed;

            //Write tag;
            bool v = lbLed1.State == LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On;
            //this.WriteTag(this.connectServerCtrl1.Session, "Channel1.Device1.v1", "Boolean",!v);
            this.WriteTag(this.connectServerCtrl1.Session, this.tagLedWrite, !v);

        }
        bool WriteTag(Session m_session, MonitoredItem tag, Object v)
        {
            Opc.Ua.WriteValue valueToWrite = new Opc.Ua.WriteValue();
            valueToWrite.AttributeId = Attributes.Value;
            //Method1
            string sType = ((MonitoredItemNotification)tag.LastValue).Value.WrappedValue.TypeInfo.BuiltInType.ToString();
            string tagID = tag.ResolvedNodeId.Identifier.ToString();
            return WriteTag(m_session, tagID, sType, v);
        }
        bool WriteTag(Session m_session,string tag, string sType, object v)
        {
            Opc.Ua.WriteValue valueToWrite = new Opc.Ua.WriteValue();
            valueToWrite.AttributeId = Attributes.Value;
            valueToWrite.NodeId = new NodeId(tag, 2);
            valueToWrite.Value.Value = GetValue(v, sType);
            valueToWrite.Value.ServerTimestamp = DateTime.MinValue;
            valueToWrite.Value.StatusCode = StatusCodes.Good;

            WriteValueCollection lstToWrite = new WriteValueCollection();
            lstToWrite.Add(valueToWrite);

            StatusCodeCollection results = null;
            DiagnosticInfoCollection lstDia = null;
            m_session.Write(null, lstToWrite, out results, out lstDia);
            ClientBase.ValidateResponse(results, lstToWrite);
            if (StatusCode.IsBad(results[0]))
            {
                return false;
            }
            return true;
        }

        private object GetValue(object v, string sType)
        {
            switch (sType)
            {
                case "Boolean":
                    return Convert.ToBoolean(v);
                case "Byte":
                    return Convert.ToByte(v);
                case "SByte":
                    return Convert.ToSByte(v);
                case "UInt16":
                    return Convert.ToUInt16(v);
                case "Int16":
                    return Convert.ToInt16(v);
                case "UInt32":
                    return Convert.ToUInt32(v);
                case "Int32":
                    return Convert.ToInt32(v);
                case "UInt64":
                    return Convert.ToUInt64(v);
                case "Int64":
                    return Convert.ToInt64(v);
                case "Double":
                    return Convert.ToDouble(v);
                case "Float":
                    return Convert.ToDateTime(v);
                case "DateTime":
                    return Convert.ToDateTime(v);
            }
            return v;
        }

        private void lbButton1_MouseUp(object sender, MouseEventArgs e)
        {
            this.lbButton1.State = LBSoft.IndustrialCtrls.Buttons.LBButton.ButtonState.Normal;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
        }
    }
    
}
