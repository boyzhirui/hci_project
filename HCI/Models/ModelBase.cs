using HCI.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HCI.Models
{
    public class ModelBase : IDisposable
    {
        [NonSerialized]
        private HciDb context = null;
        [NonSerialized]
        private bool contextInited = false;
        [NonSerialized]
        private bool needDispose = false;
        protected bool ContextInited
        {
            get { return contextInited; }
            private set { contextInited = value; }
        }
        protected HciDb Context
        {
            get
            {
                if (!ContextInited)
                {
                    context = new HciDb();
                    needDispose = true;
                }
                return context;
            }

            private set
            {
                ContextInited = true;
                context = value;
            }
        }


        public ModelBase()
        {

        }

        public ModelBase(HciDb ctx)
        {
            Context = ctx;
        }

        ~ModelBase()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected void Dispose(bool disposing)
        {
            if (needDispose)
            {
                Context.Dispose();
            }
        }
    }
}