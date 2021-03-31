import React from 'react'
import styles from './header.module.css'
import Link from '../link/link'
import logo from '../../images/white-origami-bird.png'

const Header = () => {
    return (
        <header className={styles.header}>
             <img src={logo} className={styles.image}/>
             
             <Link linkContent="LOGIN" 
                href="/login"
                title="LOg mEejqijdfiqwjdoqw"
                type="header" />
            <Link linkContent="####" type="header" reff={'#'} />
            <Link linkContent={"####"} type="header" reff={'#'} />
            <Link linkContent={"####"} type="header" reff={'#'} />
            <Link linkContent={"####"} type="header" reff={'#'} />
            <Link linkContent={"####"} type="header" reff={'#'} />
        </header>
    )
}

export default Header