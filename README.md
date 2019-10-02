# How to compile the project

Write the following command in the terminal if you have windows 10 64-bit. Change to x86 for 32-bit.

```
dotnet publish -c Release -r win10-x64
```

Write the following command in the terminal if you have macOS 10.14 Mojave. Exchange to 10.xx if you have another version. NOTE: This is not tested.

```
dotnet publish -c Release -r osx.10.14-x64
```

## After compilation

**Make sure you move the members.json to ./bin/Release/netcoreapp2.2/win10-x64/publish/**

Alternatively you can just create an empty members.json in the folder above but make sure you create an empty array inside of the file ([]) before you run the .exe.

The .exe file to run the application lies in the same folder as above.
