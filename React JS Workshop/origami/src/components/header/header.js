import React from "react";
import { useHistory } from "react-router-dom";
import logo from "../../images/white-origami-bird.png";
import LinkCustom from "../link/link";
import styles from "./header.module.css";

const Header = () => {
  const { push } = useHistory();

  return (
    <header className={styles.header}>
      <img
        onClick={() => push("/")}
        src={logo}
        alt=""
        className={styles.image}
      />
      <LinkCustom
        linkContent="LOGIN"
        reff="/login"
        title="TEST LOGIN"
        to="/login"
        type="header"
      />
      <LinkCustom
        linkContent="REGISTER"
        reff="/register"
        title="TEST REGISTER"
        type="header"
      />
    </header>
  );
};

export default Header;
