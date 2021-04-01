import React from "react";
import logo from "../../images/white-origami-bird.png";
import Link from "../link/link";
import styles from "./footer.module.css";

const Footer = () => {
  return (
    <footer className={styles.footer}>
      <Link
        linkContent="Google"
        type="footer"
        reff={"https://google.com"}
        isExternalLink
      />
      <Link linkContent="####" type="footer" reff={"#"} />
      <Link linkContent={"####"} type="footer" reff={"#"} />
      <Link linkContent={"####"} type="footer" reff={"#"} />
      <Link linkContent={"####"} type="footer" reff={"#"} />
      <Link linkContent={"####"} type="footer" reff={"#"} />
      <img src={logo} alt="" className={styles.image} />
    </footer>
  );
};

export default Footer;
