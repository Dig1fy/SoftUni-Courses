import React from 'react'
import styles from './header.module.css'
import Link from '../link/link'
import logo from '../../images/white-origami-bird.png'

const Header = () => {
    return (
        <header className={styles.header}>
             <img src={logo} className={styles.image}/>
            <Link linkContent="Post" type="header" reff={'http://localhost:9999/api/origami'} />
            <Link linkContent={"Register"} type="header" reff={'http://localhost:9999/api/user/register'} />
            <Link linkContent={"Login"} type="header" reff={'http://localhost:9999/api/user/login'} />
            <Link linkContent={"Profile"} type="header" reff={'#'} />
            <Link linkContent={5} type="header" reff={'#'} />
            <Link linkContent={6} type="header" reff={'#'} />
        </header>
    )
}

export default Header