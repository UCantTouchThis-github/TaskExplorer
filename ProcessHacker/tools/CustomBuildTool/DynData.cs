/*
 * Copyright (c) 2022 Winsider Seminars & Solutions, Inc.  All rights reserved.
 *
 * This file is part of System Informer.
 *
 * Authors:
 *
 *     jxy-s
 *
 */

namespace CustomBuildTool
{
    internal class DynData
    {
        public string Header;
        public string Source;

        private const string FileHeader =
@"/*
 * Copyright (c) 2022 Winsider Seminars & Solutions, Inc.  All rights reserved.
 *
 * This file is part of System Informer.
 *
 * THIS IS AN AUTOGENERATED FILE, DO NOT MODIFY
 *
 */";

        private const string Includes =
@"#include <kphlibbase.h>";

        private const UInt32 Version = 5;

        private string DynConfigC =
$@"#define KPH_DYN_CONFIGURATION_VERSION { Version }

#define KPH_DYN_CI_INVALID ((SHORT)-1)
#define KPH_DYN_CI_V1      ((SHORT)1)
#define KPH_DYN_CI_V2      ((SHORT)2)

#include <pshpack1.h>

typedef struct _KPH_DYN_CONFIGURATION
{{
    USHORT MajorVersion;
    USHORT MinorVersion;
    USHORT ServicePackMajor;             // -1 to ignore
    USHORT BuildNumberMin;               // -1 to ignore
    USHORT RevisionMin;                  // -1 to ignore
    USHORT BuildNumberMax;               // -1 to ignore
    USHORT RevisionMax;                  // -1 to ignore

    USHORT EgeGuid;                      // dt nt!_ETW_GUID_ENTRY Guid
    USHORT EpObjectTable;                // dt nt!_EPROCESS ObjectTable
    USHORT EreGuidEntry;                 // dt nt!_ETW_REG_ENTRY GuidEntry
    USHORT HtHandleContentionEvent;      // dt nt!_HANDLE_TABLE HandleContentionEvent
    USHORT OtName;                       // dt nt!_OBJECT_TYPE Name
    USHORT OtIndex;                      // dt nt!_OBJECT_TYPE Index
    USHORT ObDecodeShift;                // dt nt!_HANDLE_TABLE_ENTRY ObjectPointerBits
    USHORT ObAttributesShift;            // dt nt!_HANDLE_TABLE_ENTRY Attributes
    USHORT CiVersion;                    // ci.dll exports version
    USHORT AlpcCommunicationInfo;        // dt nt!_ALPC_PORT CommunicationInfo
    USHORT AlpcOwnerProcess;             // dt nt!_ALPC_PORT OwnerProcess
    USHORT AlpcConnectionPort;           // dt nt!_ALPC_COMMUNICATION_INFO ConnectionPort
    USHORT AlpcServerCommunicationPort;  // dt nt!_ALPC_COMMUNICATION_INFO ServerCommunicationPort
    USHORT AlpcClientCommunicationPort;  // dt nt!_ALPC_COMMUNICATION_INFO ClientCommunicationPort
    USHORT AlpcHandleTable;              // dt nt!_ALPC_COMMUNICATION_INFO HandleTable
    USHORT AlpcHandleTableLock;          // dt nt!_ALPC_HANDLE_TABLE Lock
    USHORT AlpcAttributes;               // dt nt!_ALPC_PORT PortAttributes
    USHORT AlpcAttributesFlags;          // dt nt!_ALPC_PORT_ATTRIBUTES Flags
    USHORT AlpcPortContext;              // dt nt!_ALPC_PORT PortContext
    USHORT AlpcSequenceNo;               // dt nt!_ALPC_PORT SequenceNo
    USHORT AlpcState;                    // dt nt!_ALPC_PORT State

}} KPH_DYN_CONFIGURATION, *PKPH_DYN_CONFIGURATION;

typedef struct _KPH_DYNDATA
{{
    ULONG Version;
    ULONG Count;
    KPH_DYN_CONFIGURATION Configs[ANYSIZE_ARRAY];

}} KPH_DYNDATA, *PKPH_DYNDATA;

#include <poppack.h>";

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct DynConfig
        {
            public UInt16 MajorVersion;
            public UInt16 MinorVersion;
            public UInt16 ServicePackMajor;
            public UInt16 BuildNumberMin;
            public UInt16 BuildNumberMax;
            public UInt16 RevisionMin;
            public UInt16 RevisionMax;

            public UInt16 EgeGuid;
            public UInt16 EpObjectTable;
            public UInt16 EreGuidEntry;
            public UInt16 HtHandleContentionEvent;
            public UInt16 OtName;
            public UInt16 OtIndex;
            public UInt16 ObDecodeShift;
            public UInt16 ObAttributesShift;
            public UInt16 CiVersion;
            public UInt16 AlpcCommunicationInfo;
            public UInt16 AlpcOwnerProcess;
            public UInt16 AlpcConnectionPort;
            public UInt16 AlpcServerCommunicationPort;
            public UInt16 AlpcClientCommunicationPort;
            public UInt16 AlpcHandleTable;
            public UInt16 AlpcHandleTableLock;
            public UInt16 AlpcAttributes;
            public UInt16 AlpcAttributesFlags;
            public UInt16 AlpcPortContext;
            public UInt16 AlpcSequenceNo;
            public UInt16 AlpcState;

            public DynConfig()
            {
                MajorVersion = 0xffff;
                MinorVersion = 0xffff;
                ServicePackMajor = 0xffff;
                BuildNumberMin = 0xffff;
                BuildNumberMax = 0xffff;
                RevisionMin = 0xffff;
                RevisionMax = 0xffff;

                EgeGuid = 0xffff;
                EpObjectTable = 0xffff;
                EreGuidEntry = 0xffff;
                HtHandleContentionEvent = 0xffff;
                OtName = 0xffff;
                OtIndex = 0xffff;
                ObDecodeShift = 0xffff;
                ObAttributesShift = 0xffff;
                CiVersion = 0xffff;
                AlpcCommunicationInfo = 0xffff;
                AlpcOwnerProcess = 0xffff;
                AlpcConnectionPort = 0xffff;
                AlpcServerCommunicationPort = 0xffff;
                AlpcClientCommunicationPort = 0xffff;
                AlpcHandleTable = 0xffff;
                AlpcHandleTableLock = 0xffff;
                AlpcAttributes = 0xffff;
                AlpcAttributesFlags = 0xffff;
                AlpcPortContext = 0xffff;
                AlpcSequenceNo = 0xffff;
                AlpcState = 0xffff;
            }

            public static readonly int SizeOf;
            static DynConfig()
            {
                SizeOf = Marshal.SizeOf<DynConfig>();
            }
        }

        public DynData(
            string SignToolPath,
            string ManifestFile,
            string KeyFile
            )
        {
            MemoryStream config64;
            MemoryStream sig64;
            MemoryStream config32;
            MemoryStream sig32;

            LoadConfig(
                ManifestFile,
                SignToolPath,
                KeyFile,
                out config64,
                out sig64,
                out config32,
                out sig32
                );
            Header = GenerateHeader();
            Source = GenerateSource(config64, sig64, config32, sig32);
        }

        private string GenerateHeader()
        {
            var sb = new StringBuilder();

            sb.AppendLine(FileHeader);
            sb.AppendLine();
            sb.AppendLine("#pragma once");
            sb.AppendLine();
            sb.AppendLine(Includes);
            sb.AppendLine();
            sb.AppendLine(DynConfigC);
            sb.AppendLine();
            sb.AppendLine("extern BYTE KphDynData[];");
            sb.AppendLine("extern ULONG KphDynDataLength;");
            sb.AppendLine("extern BYTE KphDynDataSig[];");
            sb.AppendLine("extern ULONG KphDynDataSigLength;");

            return sb.ToString();
        }

        private string GenerateSource(
            MemoryStream Config64,
            MemoryStream Sig64,
            MemoryStream Config32,
            MemoryStream Sig32
            )
        {
            var sb = new StringBuilder();

            sb.AppendLine(FileHeader);
            sb.AppendLine();
            sb.AppendLine(Includes);
            sb.AppendLine();
            sb.AppendLine("BYTE KphDynData[] =");
            sb.AppendLine("{");
            sb.AppendLine("#ifdef _WIN64");
            sb.Append(BytesToString("    ", new BinaryReader(Config64)));
            sb.AppendLine("#else");
            sb.Append(BytesToString("    ", new BinaryReader(Config32)));
            sb.AppendLine("#endif");
            sb.AppendLine("};");
            sb.AppendLine();
            sb.AppendLine("ULONG KphDynDataLength = ARRAYSIZE(KphDynData);");
            sb.AppendLine();
            sb.AppendLine("BYTE KphDynDataSig[] =");
            sb.AppendLine("{");
            sb.AppendLine("#ifdef _WIN64");
            sb.Append(BytesToString("    ", new BinaryReader(Sig64)));
            sb.AppendLine("#else");
            sb.Append(BytesToString("    ", new BinaryReader(Sig32)));
            sb.AppendLine("#endif");
            sb.AppendLine("};");
            sb.AppendLine();
            sb.AppendLine("ULONG KphDynDataSigLength = ARRAYSIZE(KphDynDataSig);");

            return sb.ToString();
        }

        private void LoadConfig(
            string ManifestFile,
            string SignToolPath,
            string KeyFile,
            out MemoryStream Config64,
            out MemoryStream Sig64,
            out MemoryStream Config32,
            out MemoryStream Sig32
            )
        {
            var xml = new XmlDocument();
            xml.Load(ManifestFile);
            var arch64 = xml.SelectSingleNode("/dyn/arch[@id='64']");
            var arch32 = xml.SelectSingleNode("/dyn/arch[@id='32']");

            LoadConfigForArch(arch64, SignToolPath, KeyFile, out Config64, out Sig64);
            LoadConfigForArch(arch32, SignToolPath, KeyFile, out Config32, out Sig32);
        }

        private void LoadConfigForArch(
            XmlNode Dyn,
            string SignToolPath,
            string KeyFile,
            out MemoryStream Config,
            out MemoryStream Sig
            )
        {
            Program.PrintColorMessage("Loading Arch: " + Dyn.Attributes.GetNamedItem("id").Value, ConsoleColor.Green);

            var configs = new List<Tuple<string, DynConfig>>();
            foreach (XmlNode data in Dyn.SelectNodes("data"))
            {
                var configName = data.Attributes.GetNamedItem("name").Value;

                Program.PrintColorMessage(configName, ConsoleColor.Cyan);

                var config = new DynConfig();
                foreach (XmlNode field in data.SelectNodes("field"))
                {
                    var value = field.Attributes.GetNamedItem("value").Value;
                    var name = field.Attributes.GetNamedItem("name").Value;
                    var member = typeof(DynConfig).GetField(name);

                    if (value.StartsWith("0x", StringComparison.OrdinalIgnoreCase))
                    {
                        value = Convert.ToUInt64(value, 16).ToString(); 
                    }
                    else if (value.Equals("-1", StringComparison.OrdinalIgnoreCase) && member.FieldType == typeof(UInt16))
                    {
                        value = ((UInt16)0xffff).ToString();
                    }

                    member.SetValue(config, Convert.ChangeType(value, member.FieldType));
                }

                configs.Add(new Tuple<string, DynConfig>(configName, config));
            }

            if (!Validate(configs))
            {
                throw new Exception("Dynamic configuration is invalid!");
            }

            var configFile = Path.GetTempPath() + Guid.NewGuid().ToString();
            var sigFile = configFile;
            configFile += ".bin";
            sigFile += ".sig";

            using (var file = new FileStream(configFile, FileMode.CreateNew))
            using (var writer = new BinaryWriter(file))
            {
                //
                // Write the version and count first, then the blocks.
                // This conforms with KPH_DYNDATA defined above.
                //
                writer.Write(Version);
                writer.Write(configs.Count);
                foreach (var (configName, config) in configs)
                {
                    var ptr = Marshal.AllocHGlobal(DynConfig.SizeOf);
                    Marshal.StructureToPtr(config, ptr, false);
                    var bytes = new byte[DynConfig.SizeOf];
                    Marshal.Copy(ptr, bytes, 0, bytes.Length);
                    Marshal.FreeHGlobal(ptr);
                    writer.Write(bytes);
                }
            }

            Win32.ShellExecute(SignToolPath, $"sign -k {KeyFile} {configFile} -s {sigFile}");

            using (var file = new FileStream(configFile, FileMode.Open))
            {
                Config = new MemoryStream();
                file.CopyTo(Config);
            }

            using (var file = new FileStream(sigFile, FileMode.Open))
            {
                Sig = new MemoryStream();
                file.CopyTo(Sig);
            }

            Win32.DeleteFile(configFile);
            Win32.DeleteFile(sigFile);
        }

        private bool Validate(List<Tuple<string, DynConfig>> Configs)
        {
            bool valid = true;

            foreach (var (configName, config) in Configs)
            {
                if (config.MajorVersion == 0xffff)
                {
                    Program.PrintColorMessage($"{configName} - MajorVersion required", ConsoleColor.Red);
                    valid = false;
                }
                if (config.MinorVersion == 0xffff)
                {
                    Program.PrintColorMessage($"{configName} - MinorVersion required", ConsoleColor.Red);
                    valid = false;
                }

                if ((config.BuildNumberMax != 0xffff) &&
                    (config.BuildNumberMin != 0xffff) &&
                    (config.BuildNumberMax < config.BuildNumberMin))
                {
                    Program.PrintColorMessage($"{configName} - BuildNumber range is invalid", ConsoleColor.Red);
                    valid = false;
                }

                if ((config.RevisionMax != 0xffff) &&
                    (config.RevisionMin != 0xffff) &&
                    (config.RevisionMax < config.RevisionMin))
                {
                    Program.PrintColorMessage($"{configName} - Revision range is invalid", ConsoleColor.Red);
                    valid = false;
                }
            }

            return valid;
        }

        private string BytesToString(string LinePrefix, BinaryReader Reader)
        {
            Reader.BaseStream.Position = 0;

            var sb = new StringBuilder();
            var bytes = new byte[8];

            while (true)
            {
                var len = Reader.Read(bytes, 0, bytes.Length);

                if (len == 0)
                {
                    break;
                }

                var hex = new StringBuilder();
                for (int i = 0; i < len; i++)
                {
                    hex.AppendFormat("0x{0:x2}, ", bytes[i]);
                }
                hex.Remove(hex.Length - 1, 1);

                sb.Append(LinePrefix);
                sb.AppendLine(hex.ToString());

                if (len < bytes.Length)
                {
                    break;
                }
            }

            return sb.ToString();
        }
    }

}
