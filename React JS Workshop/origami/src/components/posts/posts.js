import React, { useCallback, useContext, useEffect, useMemo, useState } from "react";
import UserContext from "../../Context";
import Post from "../post/post";
import styles from "./posts.module.css";
import fetchOrigamis from '../../helper-functions/getOrigamis'

const Posts = (props) => {
  const context = useContext(UserContext)
  const [origamis, setOrigamis] = useState(context.origamis || []);

  const getOrigamis = useCallback(async () => {
    let origamis = await fetchOrigamis(props.length)
    setOrigamis(origamis);
  }, [props.length]);

  const renderOrigamis = () => {
    return origamis.map((origam, currentIndex) => {
      return <Post key={origam._id} index={currentIndex + 1} {...origam} />;
    });
  }

  useEffect(() => {
    getOrigamis();
  }, [getOrigamis, props.updatedOrigami])

  return (
    <div className={styles.posts}>
      {renderOrigamis()}
    </div>
  );
}


export default Posts;
