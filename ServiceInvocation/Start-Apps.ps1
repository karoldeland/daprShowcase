
$Cart = "dapr.exe run --app-id cart --app-port 5000 --dapr-http-port 3500 --log-level info --config ./dapr-config/config.yaml --components-path ./dapr-config/ dotnet run -- --urls=http://localhost:5000/ -p cart/cart.csproj"
$Frontend = "dapr.exe run --app-id frontend --app-port 5002 --dapr-http-port 3501 --log-level info dotnet run -- --urls=http://localhost:5002/ -p frontend/frontend.csproj"


Start-Process powershell.exe -argument "`$host.ui.RawUI.WindowTitle = 'Cart Service'; $Cart"
Start-Process powershell.exe -argument "`$host.ui.RawUI.WindowTitle = 'Frontend'; $Frontend"