using Opc.Ua;
using Opc.Ua.Client;
using Opc.Ua.Client.Controls;
using Opc.Ua.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Estudo_OPC
{
    public partial class Form1 : Form
    {
        public Form1(MonitoredItem monitored = null)
        {
            InitializeComponent();
            this.monitored = monitored;
        }
        private Session m_session;
        private bool m_connectedOnce;
        private Subscription m_subscription;
        MonitoredItem monitored;
        bool v = false;

        #region Conexão
        private void connectServerCtrl1_ConnectComplete(object sender, EventArgs e)
        {
            try
            {
                m_session = connectServerCtrl1.Session;

                //definir um estado inicial
                if (m_session != null && !m_connectedOnce)
                {
                    m_connectedOnce = true;
                    //conectado
                    CreateSubscriptionAndMonitorItem();
                }
            }
            catch (Exception ex)
            {
                ClientUtils.HandleException(this.Text, ex);
            }
        }
        #endregion
        private void CreateSubscriptionAndMonitorItem()
        {
            try
            {
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
                m_subscription.PublishingInterval = 1000;
                m_subscription.Priority = 1;
                m_subscription.KeepAliveCount = 10;
                m_subscription.LifetimeCount = 20;
                m_subscription.MaxNotificationsPerPublish = 1000;

                m_session.AddSubscription(m_subscription);
                m_subscription.Create();

                //Method 1
                string[] tags = new string[]
                {
                    "Simulation Examples.Functions.User1",

                };

                Control[] ctrls = new Control[]
                {
                    label1,

                };



                for (int ii = 0; ii < tags.Length; ii++)
                {
                    ctrls[ii].Text = "---";
                    MonitoredItem monitoredItem = new MonitoredItem();
                    monitoredItem.StartNodeId = new NodeId(tags[ii], 2);
                    monitoredItem.AttributeId = Attributes.Value;
                    monitoredItem.Handle = new object[] { ctrls[ii], ctrls[ii].GetType().GetProperty("Text") };
                    monitoredItem.Notification += MonitoredItem_Notification1;
                    m_subscription.AddItem(monitoredItem);
                }

                MonitoredItem monitoredItem1 = new MonitoredItem();
                monitoredItem1.StartNodeId = new NodeId("Channel1.Device1.string", 2);
                monitoredItem1.AttributeId = Attributes.Value;
                monitoredItem1.Notification += MonitoredItem_Notification;
                m_subscription.AddItem(monitoredItem1);

                //Method 2:
                //this.textBox1.Text = "---";
                MonitoredItem monitoredItem2 = new MonitoredItem();
                monitoredItem2.StartNodeId = new NodeId("Simulation Examples.Functions.User3", 2);
                monitoredItem2.AttributeId = Attributes.Value;
                monitoredItem2.Notification += MonitoredItem2_Notification;
                m_subscription.AddItem(monitoredItem2);

                //Method 3:
                MonitoredItem monitoredItem3 = new MonitoredItem();
                monitoredItem3.StartNodeId = new NodeId("Channel1.Device1.Tag1", 2);
                monitoredItem3.AttributeId = Attributes.Value;
                monitoredItem3.Notification += MonitoredItem3_Notification;
                m_subscription.AddItem(monitoredItem3);



                m_subscription.ApplyChanges();
            }
            catch (Exception exception)
            {
                ClientUtils.HandleException(this.Text, exception);
                Console.WriteLine("CreateSubscriptionAndMonitorItem " + exception);
            }
        }

        private void MonitoredItem3_Notification(MonitoredItem monitoredItem, MonitoredItemNotificationEventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new MonitoredItemNotificationEventHandler(MonitoredItem3_Notification), monitoredItem, e);
                return;
            }
            //this.label2.Text = ((MonitoredItemNotification)e.NotificationValue).Value.WrappedValue.ToString();

            try
            {
                if ((bool)((MonitoredItemNotification)e.NotificationValue).Value.WrappedValue.Value == true)
                {
                    this.pictureBox1.Image = global::Estudo_OPC.Properties.Resources.BlueButton;
                }
                else
                {
                    this.pictureBox1.Image = global::Estudo_OPC.Properties.Resources.BlackButtonPressed;
                }
            }
            catch (Exception ex)
            {
                ClientUtils.HandleException(this.Text, ex);
                Console.WriteLine("MonitoredItem3_Notification " + ex);
            }
        }


        private void MonitoredItem2_Notification(MonitoredItem monitoredItem, MonitoredItemNotificationEventArgs e)
        {
            //if (InvokeRequired)
            //{
            //    BeginInvoke(new MonitoredItemNotificationEventHandler(MonitoredItem2_Notification), monitoredItem, e);
            //    return;
            //}
            //this.textBox1.Text = ((MonitoredItemNotification)e.NotificationValue).Value.WrappedValue.ToString();

            //if ((bool)((MonitoredItemNotification)e.NotificationValue).Value.WrappedValue.Value == true)
            //{
            //    this.pictureBox1.Image = global::Estudo_OPC.Properties.Resources.BlueButton;
            //}
            //else
            //{
            //    this.pictureBox1.Image = global::Estudo_OPC.Properties.Resources.BlackButtonPressed;
            //}
        }

        private void MonitoredItem_Notification1(MonitoredItem monitoredItem, MonitoredItemNotificationEventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new MonitoredItemNotificationEventHandler(MonitoredItem_Notification1), monitoredItem, e);
                return;
            }
            try
            {
                object[] objs = (object[])monitoredItem.Handle;
                Control control = (Control)objs[0];
                PropertyInfo proInfo = (PropertyInfo)objs[1];
                MonitoredItemNotification datachange = e.NotificationValue as MonitoredItemNotification;

                if (datachange == null)
                {
                    return;
                }
                object v = TypeDescriptor.GetConverter(datachange.Value.WrappedValue.Value.GetType()).ConvertTo(datachange.Value.WrappedValue, proInfo.PropertyType);
                if (proInfo != null)
                    proInfo.SetValue(control, v);
            }
            catch (Exception ex)
            {
                ClientUtils.HandleException(this.Text, ex);
                Console.WriteLine("MonitoredItem3_Notification " + ex);
            }
        }

        private void MonitoredItem_Notification(MonitoredItem monitoredItem, MonitoredItemNotificationEventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new MonitoredItemNotificationEventHandler(MonitoredItem_Notification), monitoredItem, e);
                return;
            }
            this.label2.Text = ((MonitoredItemNotification)e.NotificationValue).Value.WrappedValue.ToString();

        }



        private void Form1_Load(object sender, EventArgs e)
        {
            this.connectServerCtrl1.ServerUrl = "opc.tcp://DESKTOP-45J2BHI:49320";
            string AppName = "testeOPCUA";
            var configuration = new ApplicationConfiguration()
            {
                ApplicationName = AppName,
                ApplicationUri = Utils.Format(@"urn:{0}:" + AppName, System.Net.Dns.GetHostName()),
                ApplicationType = ApplicationType.Client,
                SecurityConfiguration = new SecurityConfiguration
                {
                    ApplicationCertificate = new CertificateIdentifier
                    {
                        StoreType = @"Directory",
                        StorePath = System.Windows.Forms.Application.StartupPath + @"\Cert\TrustedIssuer",
                        SubjectName = $"CN={AppName}, DC={System.Net.Dns.GetHostName()}"
                    },
                    TrustedIssuerCertificates = new CertificateTrustList
                    {
                        StoreType = @"Directory",
                        StorePath = System.Windows.Forms.Application.StartupPath + @"\Cert\TrustedIssuer"
                    },
                    TrustedPeerCertificates = new CertificateTrustList
                    {
                        StoreType = @"Directory",
                        StorePath = System.Windows.Forms.Application.StartupPath + @"\Cert\TrustedIssuer"
                    },
                    RejectedCertificateStore = new CertificateTrustList
                    {
                        StoreType = @"Directory",
                        StorePath = System.Windows.Forms.Application.StartupPath + @"\Cert\RejectedCertificates"
                    },
                    AutoAcceptUntrustedCertificates = true,
                    AddAppCertToTrustedStore = true,
                    RejectSHA1SignedCertificates = false //IMPORTANTE
                },
                TransportConfigurations = new TransportConfigurationCollection(),
                TransportQuotas = new TransportQuotas { OperationTimeout = 15000 },
                ClientConfiguration = new ClientConfiguration { DefaultSessionTimeout = 60000 },
                TraceConfiguration = new TraceConfiguration
                {
                    DeleteOnLoad = true
                },
                DisableHiResClock = false
            };
            configuration.Validate(ApplicationType.Client).GetAwaiter().GetResult();
            if (configuration.SecurityConfiguration.AutoAcceptUntrustedCertificates)
            {
                configuration.CertificateValidator.CertificateValidation += (s, ee) =>
                {
                    ee.Accept = (ee.Error.StatusCode == StatusCodes.BadCertificateUntrusted);
                };
            }
            this.connectServerCtrl1.Configuration = configuration;
            // this.connectServerCtrl1.UserIdentity = new UserIdentity("usuario", "senha"); caso queira um acesso com login e senha
            this.connectServerCtrl1.UserIdentity = new UserIdentity();
            this.connectServerCtrl1.UseSecurity = true;

            var application = new ApplicationInstance
            {
                ApplicationName = AppName,
                ApplicationType = ApplicationType.Client,
                ApplicationConfiguration = configuration
            };
            //set 0 Trace Mask => para de exibir o log na janela de saída
            Opc.Ua.Utils.SetTraceMask(0);
            application.CheckApplicationInstanceCertificate(true, 2048).GetAwaiter().GetResult(); // Cria o certificado
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.connectServerCtrl1.Disconnect();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            v = true;
            this.WriteTag(this.connectServerCtrl1.Session, this.monitored, v);
        }

        bool WriteTag(Session connectServerCtrl1, MonitoredItem monitored, bool v)
        {
            Opc.Ua.WriteValue valueWrite = new Opc.Ua.WriteValue();
            valueWrite.AttributeId = Attributes.Value;
            string sType = "Boolean";
            string tagID = "Channel1.Device1.v1";
            return WriteTag(m_session, tagID, sType, v);

        }

        bool WriteTag(Session m_session, string tagID, string sType, bool v)
        {
            Opc.Ua.WriteValue valueToWrite = new Opc.Ua.WriteValue();
            valueToWrite.AttributeId = Attributes.Value;
            valueToWrite.NodeId = new NodeId(tagID, 2);
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

        private object GetValue(bool v, string sType)
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

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                v = false;
                this.WriteTag(this.connectServerCtrl1.Session, this.monitored, v);
            }
        }

        private void button1_MouseUp(object sender, MouseEventArgs e)
        {

            v = true;
            this.WriteTag(this.connectServerCtrl1.Session, this.monitored, v);

        }

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {

            v = false;
            this.WriteTag(this.connectServerCtrl1.Session, this.monitored, v);
        }
    }
}
