$Cart= "dapr.exe run --app-id cart --app-port 5010 --dapr-http-port 3510 dotnet run -- --urls=http://localhost:5010/ -p cart/cart.csproj"

$Email= "dapr.exe run --app-id email --app-port 5011 --dapr-http-port 3511 dotnet run -- --urls=http://localhost:5011/ -p Email/Email.csproj"

$Shipping= "dapr.exe run --app-id shipping --app-port 5012 --dapr-http-port 3512 dotnet run -- --urls=http://localhost:5012/ -p Shipping/Shipping.csproj"



Start-Process powershell.exe -argument "`$host.ui.RawUI.WindowTitle = 'Cart Service'; $Cart"
Start-Process powershell.exe -argument "`$host.ui.RawUI.WindowTitle = 'Email Service'; $Email"
Start-Process powershell.exe -argument "`$host.ui.RawUI.WindowTitle = 'Shipping Service'; $Shipping"
