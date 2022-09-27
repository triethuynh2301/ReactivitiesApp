import React from "react";
import { Button, Container, Menu } from "semantic-ui-react";
import logo from "../../assets/logo.png";

const NavBar = () => {
  return (
    <Menu inverted fixed="top">
      <Container>
        <Menu.Item header>
          <img
            src={logo}
            alt="logo"
            style={{
              marginRight: 10,
            }}
          />
          Reactivities
        </Menu.Item>
        <Menu.Item name="Activities" />
        <Menu.Item>
          <Button positive content="Create Activity"></Button>
        </Menu.Item>
      </Container>
    </Menu>
  );
};

export default NavBar;
