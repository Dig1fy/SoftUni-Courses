import React, { useContext } from "react";
import logo from "../../images/white-origami-bird.png";
import Link from "../link/link";
import styles from "./footer.module.css";
import getRouteLinks from '../../helper-functions/getRouteLinks'
import UserContext from "../../Context";

const Footer = () => {
  const context = useContext(UserContext)
  const {user} = context
  const links = getRouteLinks(user);

  return (
    <footer className={styles.footer}>
      {links.map(navLink => {
        return (
          <Link
            key={navLink.title}
            linkContent={navLink.linkContent}
            reff={navLink.endPoint}
            title={navLink.title}
            type="footer"
          />
        )
      })}
      <img src={logo} alt="" className={styles.image} />
    </footer>
  );
};

export default Footer;
