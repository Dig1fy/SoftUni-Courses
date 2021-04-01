import React from 'react'
import PageLayout from '../../components/layout/layout'
import styles from './home.module.css'
import Posts from '../../components/posts/posts'

const HomePage = () => {

    return (
        <PageLayout>
            {/* <div className={styles.container}>HOME PAGEEEEEE</div> */}
            <Posts />
        </PageLayout>
    )
}

export default HomePage