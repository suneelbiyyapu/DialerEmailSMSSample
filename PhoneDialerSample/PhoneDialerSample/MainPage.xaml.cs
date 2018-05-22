using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PhoneDialerSample
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

        private void ButtonCallClicked(object sender, EventArgs e)
        {
            string phoneNumber = entryPhoneNumber.Text;

            if (string.IsNullOrEmpty(phoneNumber))
            {
                return;
            }

            // Following line used to display given phone number in dialer
            Device.OpenUri(new Uri(String.Format("tel:{0}", phoneNumber)));
        }

        private void ButtonSMSClicked(object sender, EventArgs e)
        {
            string smsPhoneNumber = entryMessgeTo.Text;
            string smsText = entryMessageText.Text;

            if (string.IsNullOrEmpty(smsPhoneNumber))
            {
                return;
            }

            // Following line used to open Messages app and populate below given details
            if (Device.RuntimePlatform == Device.iOS)
            {
                Device.OpenUri(new Uri(String.Format("sms:{0}&body={1}", smsPhoneNumber, smsText)));
            }
            else if (Device.RuntimePlatform == Device.Android)
            {
                Device.OpenUri(new Uri(String.Format("sms:{0}?body={1}", smsPhoneNumber, smsText)));
            }
        }

        private void ButtonMailClicked(object sender, EventArgs e)
        {
            string toEmail = entryEmail.Text;
            string emailSubject = entryEmailSubject.Text;
            string emailBody = editorEmailBody.Text;

            if (string.IsNullOrEmpty(toEmail))
            {
                return;
            }

            Device.OpenUri(new Uri(String.Format("mailto:{0}?subject={1}&body={2}", toEmail, emailSubject, emailBody)));
        }
    }
}
