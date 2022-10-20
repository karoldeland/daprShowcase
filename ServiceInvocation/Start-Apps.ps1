
#$Cart = "dapr.exe run --app-id cart --app-port 5000 --dapr-http-port 3500 dotnet run -- --urls=http://localhost:5000/ -p cart/cart.csproj"
$Cart = "cd C:\Users\karol\source\repos\daprShowcaseNode; dapr.exe run --app-id cart --app-port 5000 --dapr-http-port 3500 node app.js"
$Frontend = "dapr.exe run --app-id frontend --app-port 5002 --dapr-http-port 3501 dotnet run -- --urls=http://localhost:5002/ -p frontend/frontend.csproj"


Start-Process powershell.exe -argument "`$host.ui.RawUI.WindowTitle = 'Cart Service'; $Cart"
Start-Process powershell.exe -argument "`$host.ui.RawUI.WindowTitle = 'Frontend'; $Frontend"