# SomeApp

Really simple test app for SPCE

## prerequisites
* dotNet core 5.x
* Nodejs 10.24.x
  
## How to run
### backend
on terminal 1
```bash
cd ./be/someapp
dotnet build
dotnet run
```
server should start on https://localhost:5001

just for simplicity, there are a few notices:
  * the api is using a simple in-memory datastore
  * no requests validation
  * all exception throw by the API will be converted to status code 500 with a single <i>message</i> field in body
### frontend
on terminal 2
```bash
cd ./fe/some-app
npm install
npm start
```
app should start on http://localhost:3000
## License
[MIT](https://choosealicense.com/licenses/mit/)