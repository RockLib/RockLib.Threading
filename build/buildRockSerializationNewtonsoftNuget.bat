msbuild /p:Configuration=Release ..\Rock.Serialization.Netwonsoft\Rock.Serialization.Netwonsoft.csproj
nuget pack ..\Rock.Serialization.Netwonsoft\Rock.Serialization.Netwonsoft.csproj -Properties Configuration=Release