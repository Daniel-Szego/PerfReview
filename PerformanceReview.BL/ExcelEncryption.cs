using System;
using System.Collections.Generic;
using System.Text;

namespace OfficeOpenXml
{
    /// <summary>
    /// Encryption Algorithm
    /// </summary>
    public enum EncryptionAlgorithm
    {
        /// <summary>
        /// 128-bit AES. Default
        /// </summary>
        AES128,
        /// <summary>
        /// 192-bit AES.
        /// </summary>
        AES192,
        /// <summary>
        /// 256-bit AES. 
        /// </summary>
        AES256
    }
    /// <summary>
    /// How and if the workbook is encrypted
    ///<seealso cref="ExcelProtection"/> 
    ///<seealso cref="ExcelSheetProtection"/> 
    /// </summary>
    public class ExcelEncryption
    {
        /// <summary>
        /// Constructor
        /// </summary>
        internal ExcelEncryption()
        {
            Algorithm = EncryptionAlgorithm.AES128;
        }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="encryptionAlgorithm">Algorithm used to encrypt the package. Default is AES128</param>
        internal ExcelEncryption(EncryptionAlgorithm encryptionAlgorithm)
        {
            Algorithm = encryptionAlgorithm;
        }        
        bool _isEncrypted = false;
        /// <summary>
        /// Is the package encrypted
        /// </summary>
        public bool IsEncrypted 
        {
            get
            {
                return _isEncrypted;
            }
            set
            {
                _isEncrypted = value;
                if (_isEncrypted)
                {
                    if (_password == null) _password = "";
                }
                else
                {
                    _password = null;
                }
            }
        }
        string _password=null;
        /// <summary>
        /// The password used to encrypt the workbook.
        /// </summary>
        public string Password 
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                _isEncrypted = (value != null);
            }
        }
        /// <summary>
        /// Algorithm used for encrypting the package. Default is AES 128-bit
        /// </summary>
        public EncryptionAlgorithm Algorithm { get; set; }
    }
}
