using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;

namespace DXApp24.Module.BusinessObjects.Example
{
    [DefaultClassOptions]
    public class Driver : BaseObject
    { 
        public Driver(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }


        string test2;
        string test;

        public string Test
        {
            get => test;
            set => SetPropertyValue(nameof(Test), ref test, value);
        }
        
        public string Test2
        {
            get => test2;
            set => SetPropertyValue(nameof(Test2), ref test2, value);
        }
    }
}