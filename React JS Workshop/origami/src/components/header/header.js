import React from 'react'
import styles from './header.module.css'
import Link from '../link/link'


const Header = () => {
    return (
        <header className={styles.header}>
            <Link number={1} type="header" reff={'https://google.com'} />
            <Link number={2} type="header" reff={'#'} />
            <Link number={3} type="header" reff={'#'} />
            <Link number={4} type="header" reff={'#'} />
            <Link number={5} type="header" reff={'#'} />
            <Link number={6} type="header" reff={'#'} />
        </header>
    )
}

export default Header