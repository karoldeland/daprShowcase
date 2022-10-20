$Cart= "dapr.exe run --app-id cart --app-port 5010 --dapr-http-port 3510 dotnet run -- --urls=http://localhost:5010/ -p cart/cart.csproj"

$Email1= "dapr.exe run --app-id email --app-port 5011 --dapr-http-port 3511 dotnet run -- --urls=http://localhost:5011/ -p Email/Email.csproj"

$Email2= "dapr.exe run --app-id email --app-port 5012 --dapr-http-port 3512 dotnet run -- --urls=http://localhost:5012/ -p Email/Email.csproj"




Start-Process powershell.exe -argument "`$host.ui.RawUI.WindowTitle = 'Cart Service'; $Cart; Read-host"
Start-Process powershell.exe -argument "`$host.ui.RawUI.WindowTitle = 'Email Service Instance 1'; $Email1;Read-host"
Start-Process powershell.exe -argument "`$host.ui.RawUI.WindowTitle = 'Email Service Instance 2'; $Email2;Read-host"