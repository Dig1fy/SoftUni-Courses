import React, { useContext } from 'react'
import Link from '../link/link'
import styles from './aside.module.css'
import getRouteLinks from '../../helper-functions/getRouteLinks'
import UserContext from '../../Context'

const Aside = () => {
    const context = useContext(UserContext)
    const { user } = context
    const links = getRouteLinks(user);

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