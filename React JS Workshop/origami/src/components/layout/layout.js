import React from "react";
import Footer from "../../components/footer/footer";
import Header from "../../components/header/header";
import styles from "./layout.module.css";
import Aside from "../aside/aside";

const Layout = (props) => {
  return (
    <div className={styles.container}>
      <Header />
      <div>
        <Aside />
        <div>{props.children}</div>
        {/* <Posts /> */}
      </div>
      <Footer />
    </div>
  );
};

export default Layout;
