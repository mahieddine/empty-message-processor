namespace mbc.com.ProcessEmptyFile.Pipeline
{
    using System;
    using System.IO;
    using System.Text;
    using System.Drawing;
    using System.Resources;
    using System.Reflection;
    using System.Diagnostics;
    using System.Collections;
    using System.ComponentModel;
    using Microsoft.BizTalk.Message.Interop;
    using Microsoft.BizTalk.Component.Interop;
    using Microsoft.BizTalk.Component;
    using Microsoft.BizTalk.Messaging;
    
    
    [ComponentCategory(CategoryTypes.CATID_PipelineComponent)]
    [System.Runtime.InteropServices.Guid("71da7242-bd62-41fa-91a0-e8df338b2f3b")]
    [ComponentCategory(CategoryTypes.CATID_Decoder)]
    public class ProcessEmptyMessage : Microsoft.BizTalk.Component.Interop.IComponent, IBaseComponent, IPersistPropertyBag, IComponentUI
    {

        private System.Resources.ResourceManager resourceManager = new System.Resources.ResourceManager("mbc.com.ProcessEmptyFile.Pipeline.ProcessEmptyMessage", Assembly.GetExecutingAssembly());
        
        private string _ContextPropertyName;
        
        public string ContextPropertyName
        {
            get
            {
                return _ContextPropertyName;
            }
            set
            {
                _ContextPropertyName = value;
            }
        }


        private string _ContextPropertyNamespace;

        public string ContextPropertyNamespace
        {
            get
            {
                return _ContextPropertyNamespace;
            }

            set
            {
                _ContextPropertyNamespace = value;
            }
        }
        private string _DefaultMessage;
        
        public string DefaultMessage
        {
            get
            {
                return _DefaultMessage;
            }
            set
            {
                _DefaultMessage = value;
            }
        }
        

        

        #region IBaseComponent members
        /// <summary>
        /// Name of the component
        /// </summary>
        [Browsable(false)]
        public string Name
        {
            get
            {
                return resourceManager.GetString("COMPONENTNAME", System.Globalization.CultureInfo.InvariantCulture);
            }
        }
        
        /// <summary>
        /// Version of the component
        /// </summary>
        [Browsable(false)]
        public string Version
        {
            get
            {
                return resourceManager.GetString("COMPONENTVERSION", System.Globalization.CultureInfo.InvariantCulture);
            }
        }
        
        /// <summary>
        /// Description of the component
        /// </summary>
        [Browsable(false)]
        public string Description
        {
            get
            {
                return resourceManager.GetString("COMPONENTDESCRIPTION", System.Globalization.CultureInfo.InvariantCulture);
            }
        }
        #endregion
        
        #region IPersistPropertyBag members
        /// <summary>
        /// Gets class ID of component for usage from unmanaged code.
        /// </summary>
        /// <param name="classid">
        /// Class ID of the component
        /// </param>
        public void GetClassID(out System.Guid classid)
        {
            classid = new System.Guid("71da7242-bd62-41fa-91a0-e8df338b2f3b");
        }
        
        /// <summary>
        /// not implemented
        /// </summary>
        public void InitNew()
        {
        }
        
        /// <summary>
        /// Loads configuration properties for the component
        /// </summary>
        /// <param name="pb">Configuration property bag</param>
        /// <param name="errlog">Error status</param>
        public virtual void Load(Microsoft.BizTalk.Component.Interop.IPropertyBag pb, int errlog)
        {
            object val = null;
            val = this.ReadPropertyBag(pb, "ContextPropertyName");
            if ((val != null))
            {
                this._ContextPropertyName = ((string)(val));
            }
            
            val = this.ReadPropertyBag(pb, "DefaultMessage");
            if ((val != null))
            {
                this._DefaultMessage = ((string)(val));
            }

            val = this.ReadPropertyBag(pb, "ContextPropertyNamespace");
            if ((val != null))
            {
                this._ContextPropertyNamespace = ((string)(val));
            }
        }
        
        /// <summary>
        /// Saves the current component configuration into the property bag
        /// </summary>
        /// <param name="pb">Configuration property bag</param>
        /// <param name="fClearDirty">not used</param>
        /// <param name="fSaveAllProperties">not used</param>
        public virtual void Save(Microsoft.BizTalk.Component.Interop.IPropertyBag pb, bool fClearDirty, bool fSaveAllProperties)
        {
            this.WritePropertyBag(pb, "ContextPropertyName", this.ContextPropertyName);
            this.WritePropertyBag(pb, "ContextPropertyNamespace", this.ContextPropertyNamespace);
            this.WritePropertyBag(pb, "DefaultMessage", this.DefaultMessage);
        }
        
        #region utility functionality
        /// <summary>
        /// Reads property value from property bag
        /// </summary>
        /// <param name="pb">Property bag</param>
        /// <param name="propName">Name of property</param>
        /// <returns>Value of the property</returns>
        private object ReadPropertyBag(Microsoft.BizTalk.Component.Interop.IPropertyBag pb, string propName)
        {
            object val = null;
            try
            {
                pb.Read(propName, out val, 0);
            }
            catch (System.ArgumentException )
            {
                return val;
            }
            catch (System.Exception e)
            {
                throw new System.ApplicationException(e.Message);
            }
            return val;
        }
        
        /// <summary>
        /// Writes property values into a property bag.
        /// </summary>
        /// <param name="pb">Property bag.</param>
        /// <param name="propName">Name of property.</param>
        /// <param name="val">Value of property.</param>
        private void WritePropertyBag(Microsoft.BizTalk.Component.Interop.IPropertyBag pb, string propName, object val)
        {
            try
            {
                pb.Write(propName, ref val);
            }
            catch (System.Exception e)
            {
                throw new System.ApplicationException(e.Message);
            }
        }
        #endregion
        #endregion
        
        #region IComponentUI members
        /// <summary>
        /// Component icon to use in BizTalk Editor
        /// </summary>
        [Browsable(false)]
        public IntPtr Icon
        {
            get
            {
                return ((System.Drawing.Bitmap)(this.resourceManager.GetObject("COMPONENTICON", System.Globalization.CultureInfo.InvariantCulture))).GetHicon();
            }
        }
        
        /// <summary>
        /// The Validate method is called by the BizTalk Editor during the build 
        /// of a BizTalk project.
        /// </summary>
        /// <param name="obj">An Object containing the configuration properties.</param>
        /// <returns>The IEnumerator enables the caller to enumerate through a collection of strings containing error messages. These error messages appear as compiler error messages. To report successful property validation, the method should return an empty enumerator.</returns>
        public System.Collections.IEnumerator Validate(object obj)
        {
            // example implementation:
            // ArrayList errorList = new ArrayList();
            // errorList.Add("This is a compiler error");
            // return errorList.GetEnumerator();
            return null;
        }
        #endregion
        
        #region IComponent members
        /// <summary>
        /// Implements IComponent.Execute method.
        /// </summary>
        /// <param name="pc">Pipeline context</param>
        /// <param name="inmsg">Input message</param>
        /// <returns>Original input message</returns>
        /// <remarks>
        /// IComponent.Execute method is used to initiate
        /// the processing of the message in this pipeline component.
        /// </remarks>
        public Microsoft.BizTalk.Message.Interop.IBaseMessage Execute(Microsoft.BizTalk.Component.Interop.IPipelineContext pc, Microsoft.BizTalk.Message.Interop.IBaseMessage inmsg)
        {
            IBaseMessage baseMessage = inmsg;
            string eventSource = "ProcessEmptyMessage Pipeline Component"; 
            // if message isn't empty
            if (baseMessage.BodyPart.Data.Length != (long)0)
            {
                // not empty
                if (!string.IsNullOrEmpty(this.ContextPropertyName) && !string.IsNullOrEmpty(this.ContextPropertyNamespace))
                {
                    try
                    {
                        baseMessage.Context.Promote(this.ContextPropertyName, this.ContextPropertyNamespace, false);
                    }
                    catch (Exception e)
                    {
                        System.Diagnostics.EventLog.WriteEntry(eventSource, e.Message, EventLogEntryType.Error);
                    }
                }
            }

            else
            {
                // if there is something to replace 
                if (!string.IsNullOrEmpty(this.DefaultMessage))
                {
                    char NewLine = (char)0x0A;
                    char CariageReturn  = (char)0x0D;
                    MemoryStream memoryStream = new MemoryStream(Encoding.GetEncoding(1252).GetBytes(this.DefaultMessage.Replace(@"\r", CariageReturn.ToString()).Replace(@"\n", NewLine.ToString())));                 
                    memoryStream.Flush();
                    memoryStream.Position = (long)0;
                    baseMessage.BodyPart.Data = memoryStream;                    
                }

                // if we should promote the property that will indicate if this file is empty or not
                if(!string.IsNullOrEmpty(this.ContextPropertyName) && !string.IsNullOrEmpty(this.ContextPropertyNamespace))
                {
                    try
                    {
                        baseMessage.Context.Promote(this.ContextPropertyName, this.ContextPropertyNamespace, true);
                    }
                    catch (Exception e)
                    {
                        System.Diagnostics.EventLog.WriteEntry(eventSource, e.Message, EventLogEntryType.Error);
                    }
                }

            }

            return baseMessage;
        }
        #endregion
    }
}
