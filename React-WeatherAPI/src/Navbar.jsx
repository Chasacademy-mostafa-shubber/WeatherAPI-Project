import {Link} from 'react-router-dom';


function Navbar(){



    return (
        <>
        <ul>
        <Link to="/">Home | </Link>
        <Link to="/stockholmcity">Stockholm City | </Link>
        <Link to="/favoritecity">Favorite City</Link>
        </ul>
        </>
    )
}

export default Navbar;