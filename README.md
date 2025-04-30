# PacketIO SDK

A minimal, fast and cross-platform binary packet reader/writer for Unity and .NET.  
Supports BigEndian, UTF-8 strings, and all common primitive types.

---

## ✨ Features

- ✅ BigEndian support for all types (short, int, long, etc.)
- ✅ UTF-8 string encoding with automatic length prefixing
- ✅ Minimal dependencies — pure C# (.NET Standard 2.1)
- ✅ Works seamlessly on Unity (2021+) and .NET 6/8
- ✅ Clean API for writing and reading binary packets

---

## 🔧 Example Usage

### ✍️ Writing a packet

```csharp
var writer = new PacketWriter();
writer.SetInt(42);
writer.SetString("Hello World");
writer.SetBool(true);
byte[] data = writer.GetBytes(); // Send this over the network
```

### 📥 Reading a packet
```csharp
var reader = new PacketReader(data); // data is byte[] received from the network
int number = reader.GetInt();
string message = reader.GetString();
bool flag = reader.GetBool();
```

---

## 🛠️ Supported Types
- short, ushort
- int, uint
- long
- bool
- string (UTF-8 with 4-byte length prefix)
- byte[] (manual length handling)