import React from 'react'
import Link from '../link/link'
import styles from './aside.module.css'
import getRouteLinks from '../../helper-functions/getRouteLinks'

const Aside = () => {
    const links = getRouteLinks();

    return (
        <aside className={styles.container}>
            {links.map(navLink => {
                return (
                    <Link
                        key={navLink.title}
                        linkContent={navLink.linkContent}
                        reff={navLink.endPoint}
                        title={navLink.title}
                        type="aside"
                    />
                )
            })}

        </aside>
    )
}

export default Aside