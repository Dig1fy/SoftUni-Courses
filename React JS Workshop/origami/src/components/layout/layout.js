import React from "react";
import Footer from "../../components/footer/footer";
import Header from "../../components/header/header";
import styles from "./layout.module.css";
import Aside from "../aside/aside";

const Layout = (props) => {
  return (
    <div className={styles.app}>
      <Header />
      <div className={styles.container}>
        <Aside />
        <div className={styles['inner-container']}>
          <div>{props.children}</div>
        </div>
      </div>
      <Footer />
    </div>
  );
};

export default Layout;
