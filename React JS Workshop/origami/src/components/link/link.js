/* eslint-disable no-restricted-globals */
/* eslint-disable jsx-a11y/anchor-is-valid */
import React from "react";
import { useHistory } from "react-router-dom";
import styles from "./link.module.css";

const Link = ({ reff, linkContent, type, title, isExternalLink }) => {
  const { push } = useHistory();

  return (
    <div
      onClick={() => {
        if (isExternalLink) {
          window.open(reff);
        } else {
          push(reff);
        }
      }}
      className={styles[`${type}-list-item`]}
    >
      <a className={styles[`${type}-link`]} title={title}>{`${linkContent || "########"}`}</a>
    </div>
  );
};

export default Link;
