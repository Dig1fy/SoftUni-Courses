import React, { useContext } from "react";
import logo from "../../images/white-origami-bird.png";
import LinkCustom from "../link/link";
import styles from "./header.module.css";
import getRouteLinks from '../../helper-functions/getRouteLinks'
import UserContext from '../../Context'

const Header = () => {
  const context = useContext(UserContext)
  const { user } = context
  const links = getRouteLinks(user);

  return (
    <header className={styles.header}>
      <img src={logo} alt="" className={styles.image} />

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


export default Header

// class Header extends React.Component {

//   static contextType = UserContext

//   render() {
//     const { user } = this.context
//     const links = getRouteLinks(user);

//     return (
//       <header className={styles.header}>
//         <img src={logo} alt="" className={styles.image} />

//         {links.map(navLink => {
//           return (
//             <LinkCustom
//               key={navLink.title}
//               linkContent={navLink.linkContent}
//               reff={navLink.endPoint}
//               title={navLink.title}
//               type="header"
//             />
//           )
//         })}

//       </header>
//     );
//   }
// }

// export default Header;
