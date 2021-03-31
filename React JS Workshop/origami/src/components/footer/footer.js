import React from 'react'
import Link from '../link/link'
import styles from './footer.module.css'
import logo from '../../images/white-origami-bird.png'

const Footer = () => {
    return (
        <footer className={styles.footer}>
            <Link linkContent="Google" type="footer" reff={'https://google.com'} />
            <Link linkContent="####" type="footer" reff={'#'} />
            <Link linkContent={"####"} type="footer" reff={'#'} />
            <Link linkContent={"####"} type="footer" reff={'#'} />
            <Link linkContent={"####"} type="footer" reff={'#'} />
            <Link linkContent={"####"} type="footer" reff={'#'} />
            <img src={logo} className = {styles.image}/>
        </footer>
    )
}

export default Footer