
# Aplicação para monitoramento do preço de ativos

Executável: desafio-inoa-gabriel-console/bin/Release/net6.0/win-x64/desafio-inoa-gabriel-console.exe

Uso através do prompt de comando. Ex.: desafio-inoa-gabriel-console/bin/Release/net6.0/win-x64/desafio-inoa-gabriel-console.exe VALE3.SA <preço superior> <preço inferior>

## Environment Variables

O sistema deve as variáveis de ambiente abaixo configuradas. Elas podem tanto ser configuradas diretamente nas configurações de variáveis de ambiente do Windows, quanto serem definidas em um arquivo .env, nesse caso tal arquivo deverá ser movido pelo usuário para o diretório desafio-inoa-gabriel-console/bin/Release/net6.0/win-x64.

`SMTP_SERVER=<smtp server>`. Ex.: `SMTP_SERVER=smtp.gmail.com`

`SMTP_PORT=<número da porta>`. Ex.: `SMTP_PORT=587`

`SENDER_EMAIL=<email envio>`. Ex.: `SENDER_EMAIL=99gabrieljss@gamil.com`

`TARGET_EMAIL=<email destinatário>`. Ex.: `TARGET_EMAIL=99gabrieljss@gamil.com`

`SENDER_PASSWORD=<credencial email de envio>`. Obs.: Para contas com two-factor authentication, recomenda-se o uso de app-specific-passwords.

`API_KEY=aaaaaa`

