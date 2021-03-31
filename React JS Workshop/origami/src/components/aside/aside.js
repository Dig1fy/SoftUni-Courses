import React from 'react'
import Link from '../link/link'
import styles from './aside.module.css'

const Aside = () => {
    return (
        <aside className={styles.aside}>
            <Link number={1} type="aside" reff={'https://google.com'} />
            <Link number={2} type="aside" reff={'#'} />
            <Link number={3} type="aside" reff={'#'} />
            <Link number={4} type="aside" reff={'#'} />
            <Link number={5} type="aside" reff={'#'} />
            <Link number={6} type="aside" reff={'#'} />
            
        </aside>
    )
}

export default Aside