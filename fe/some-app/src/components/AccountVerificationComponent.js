import React from "react";
import { Form, Input, InputNumber, Button, Radio, Table } from "antd";
import { Component } from "react";
import axios from "axios";
import config from "../config";
import { withRouter } from "react-router-dom";
import { Spin, Space } from "antd";
const FormItem = Form.Item;

class AccountVerificationComponent extends Component {
  constructor() {
    super();
    this.state = {
      spinning: true,
    };
    this.eventHandlers.verify = this.eventHandlers.verify.bind(this);
  }
  eventHandlers = {
    verify: (token) => {
      return axios.post(`${config.API_ENDPOINT}/accountverification`, {
        verificationToken: token,
      });
    },
  };
  componentDidMount() {
    this.eventHandlers
      .verify(this.props.match.params.token)
      .then((r) => {
        if (r.status === 200) {
          this.setState({ redirecting: true, spinning: false });
          setTimeout(() => {
            this.props.history.push("/home");
          }, 5000);
        } else {
          alert("something went wrong!...");
        }
      })
      .catch((e) => {
        console.log(e);
        alert("something went wrong!..." + e.response.data.message);
      });
  }
  render() {
    return (
      <div>
        <Space
          size="middle"
          style={{
            display: "flex",
            justifyContent: "center",
            alignItems: "center",
          }}
        >
          <Spin
            tip="Verifying..."
            spinning={this.state.spinning}
            size="large"
          />
          {this.state.redirecting && (
            <p>Success. Redirecting to home page...</p>
          )}
        </Space>
      </div>
    );
  }
}

export default withRouter(AccountVerificationComponent);
