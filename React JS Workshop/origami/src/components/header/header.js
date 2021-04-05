import React from "react";
import { NavLink, useHistory } from "react-router-dom";
import logo from "../../images/white-origami-bird.png";
import LinkCustom from "../link/link";
import styles from "./header.module.css";
import getRouteLinks from '../../helper-functions/getRouteLinks'
import UserContext from '../../Context'

class Header extends React.Component {

  static contextType = UserContext

  render() {
    const {
      user
    } = this.context

    const links = getRouteLinks();

    return (
      <header className={styles.header}>
        <img
          onClick={() => this.props.history.push('/')}
          src={logo}
          alt=""
          className={styles.image}
        />
        {links.map(navLink => {
          return (
            <LinkCustom
              key={navLink.title}
              linkContent={navLink.linkContent}
              reff={navLink.endPoint}
              title={navLink.title}
              type="header"
            />
          )
        })}
      </header>
    );
  }
}

export default Header;
