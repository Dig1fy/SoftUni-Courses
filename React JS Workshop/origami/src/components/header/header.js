import React from "react";
import { NavLink, useHistory } from "react-router-dom";
import logo from "../../images/white-origami-bird.png";
import LinkCustom from "../link/link";
import styles from "./header.module.css";
import getRouteLinks from '../../helper-functions/getRouteLinks'

const Header = () => {
  const { push } = useHistory();
  // const { user } = this.context
  const links = getRouteLinks();

  return (
    <header className={styles.header}>
      <img
        onClick={() => push("/")}
        src={logo}
        alt=""
        className={styles.image}
      />
      {links.map(navLink=>{
        return (
          <LinkCustom
            key = {navLink.title}
            linkContent={navLink.linkContent}
            reff={navLink.endPoint}
            title={navLink.title}
            type="header"
          />
        )
      })}
    </header>
  );
};

export default Header;
