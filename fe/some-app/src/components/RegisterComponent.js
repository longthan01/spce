import React from "react";
import { Form, Input, Button, Row, Col, Spin } from "antd";
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
      <Row
        type="flex"
        justify="center"
        align="middle"
        style={{ minHeight: "100vh" }}
      >
        <Spin spinning={this.state.loading}>
          <Form
            style={{ minWidth: "500px" }}
            labelCol={{ span: 4 }}
            wrapperCol={{ span: 20 }}
            validateMessages={validationMessages}
          >
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
            <FormItem
              name="password"
              label="Password"
              rules={[{ required: true }]}
            >
              <Input
                autoComplete="off"
                type="password"
                onChange={(e) => this.setState({ password: e.target.value })}
                placeholder="Your password"
              />
            </FormItem>
            <FormItem name="fullname" label="Full name">
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
            <FormItem wrapperCol={{ offset: 4, span: 20 }}>
              <Button type="primary" onClick={this.eventHandlers.register}>
                Register
              </Button>
            </FormItem>
          </Form>
        </Spin>
      </Row>
    );
  }
}

export default withRouter(RegisterComponent);
