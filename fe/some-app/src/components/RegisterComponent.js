import React from "react";
import { Form, Input, InputNumber, Button, Radio, Table, Spin } from "antd";
import { Component } from "react";
import axios from "axios";
import config from "../config";
import { withRouter } from "react-router-dom";
const FormItem = Form.Item;

class RegisterComponent extends Component {
  state = {
    username: null,
    password: null,
    loading: false,
  };
  eventHandlers = {
    register: (event) => {
      this.setState({ loading: true });
      axios
        .post(`${config.API_ENDPOINT}/accounts`, {
          username: this.state.username,
          password: this.state.password,
          fullname: this.state.fullname,
          address: this.state.address
        })
        .then((response) => {
          if (response.status === 201) {
            alert("email sent, to go email to verify!");
          }
        })
        .catch((err) => {
          console.log(err);
          alert(err.response.data.message);
        })
        .finally(() => this.setState({ loading: false }));
    },
  };

  render() {
    const validationMessages = {
      required: "${label} is required!",
      types: {
        email: "${label} is not a valid email!",
      },
    };
    return (
      <div>
        <Spin spinning={this.state.loading}>
          <Form validateMessages={validationMessages}>
            <FormItem
              name="username"
              rules={[{ required: true }, { type: "email" }]}
              label="Email"
            >
              <Input
                autoComplete="off"
                type="email"
                onChange={(e) => this.setState({ username: e.target.value })}
                placeholder="Your email, must be an email"
              />
            </FormItem>
            <FormItem name="password" label="Password">
              <Input
                autoComplete="off"
                type="password"
                onChange={(e) => this.setState({ password: e.target.value })}
                placeholder="Your password"
              />
            </FormItem>
            <FormItem
              name="fullname"
              label="Full name"
            >
              <Input
                autoComplete="off"
                type="text"
                onChange={(e) => this.setState({ fullname: e.target.value })}
                placeholder="Full name"
              />
            </FormItem>
            <FormItem name="address" label="Address">
              <Input
                autoComplete="off"
                type="text"
                onChange={(e) => this.setState({ address: e.target.value })}
                placeholder="Address"
              />
            </FormItem>
            <FormItem>
              <Button onClick={this.eventHandlers.register}>Register</Button>
            </FormItem>
          </Form>
        </Spin>
      </div>
    );
  }
}

export default withRouter(RegisterComponent);
