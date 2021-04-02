import React from 'react'
import PageLayout from '../../components/layout/layout'
import Posts from '../../components/posts/posts'
import Title from '../../components/title/title'

const HomePage = () => {

    return (
        <PageLayout>
            <Title title={'Home page publications'}/>
            <Posts />
        </PageLayout>
    )
}

export default HomePage