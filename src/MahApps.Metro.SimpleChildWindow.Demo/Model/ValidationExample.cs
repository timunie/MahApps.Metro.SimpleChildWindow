using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MahApps.Metro.SimpleChildWindow.Demo.Model
{
    public class ValidationExample : ViewModelBaseClass
    {
        public ValidationExample()
        {
            Validate();
        }

        private string _Name;
        public string Name
        {
            get { return _Name; }
            set { _Name = value; RaisePropertyChanged(nameof(Name)); Validate(); }
        }

        private string _MailAddress;
        public string MailAddress
        {
            get { return _MailAddress; }
            set { _MailAddress = value; RaisePropertyChanged(nameof(MailAddress)); Validate(); }
        }

        void Validate()
        {
            ClearErrors(nameof(Name));
            ClearErrors(nameof(MailAddress));

            if (string.IsNullOrWhiteSpace(Name)) AddError(nameof(Name), "Name should not be Empty");
            if (string.IsNullOrWhiteSpace(MailAddress)) AddError(nameof(MailAddress), "E-Mail should not be Empty");
            if (!Regex.IsMatch(MailAddress ?? string.Empty, ".+\\@.+\\..+")) AddError(nameof(MailAddress), "E-Mail is not valid");
        }
    }
}
