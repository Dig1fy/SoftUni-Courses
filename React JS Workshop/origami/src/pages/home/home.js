import React from 'react'
import PageLayout from '../../components/layout/layout'
import Posts from '../../components/posts/posts'
import Title from '../../components/title/title'

const HomePage = () => {
    return (
        <PageLayout>
            <Title title={'Home page publications'}/>
            <Posts length={20}/>
        </PageLayout>
    )
}

// -------------- Class component ------------------
// class HomePage extends React.Component {
//     constructor(props) {
//         super(props)
//     }

//     static contextType = UserContext
//     render() {
//         // console.log(this.context, "HOME PAGEEEEEEE")
//         return (
//             <PageLayout>
//                 <Title title={'Home page publications'} />
//                 <Posts length={20} />
//             </PageLayout>
//         )
//     }
// }

export default HomePage