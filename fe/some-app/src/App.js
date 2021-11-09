import logo from "./logo.svg";
import "./App.css";
import { Layout, Menu, Breadcrumb } from "antd";
import RegisterComponent from "./components/RegisterComponent";
import HomeComponent from "./components/HomeComponent";
import AccountVerificationComponent from "./components/AccountVerificationComponent";
import { BrowserRouter as Router, Route, Link, Switch } from "react-router-dom";
const { Header, Content, Footer } = Layout;

function App() {
  return (
    <Router>
      <Layout className="layout">
        <Content style={{ padding: "50px 50px 50px 50px" }}>
          <Switch>
            <Route exact path="/" >
            <RegisterComponent />
            </Route>
            <Route exact path="/home"> <HomeComponent /></Route>
            <Route
              exact
              path="/accountverification/:token"
            ><AccountVerificationComponent /></Route>
          </Switch>
        </Content>
      </Layout>
    </Router>
  );
}

export default App;
