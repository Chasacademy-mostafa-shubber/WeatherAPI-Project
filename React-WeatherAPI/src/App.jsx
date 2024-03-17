import { BrowserRouter as Router, Route, Routes} from 'react-router-dom';
import Navbar from './Navbar';
import Home from './Home';
import StockholmCity from './StockholmCity'
import FavoriteCity from './FavoriteCity';
import './App.css'

function App() {
 

  return (
    <>
    
    <Router>
      <Navbar/>

      <Routes>
      <Route path="/" element={<Home />} />
      <Route path="/stockholmcity" element={<StockholmCity />} />
      <Route path="/favoritecity" element={<FavoriteCity />} />
      </Routes>
    </Router>
    </>
  )
}

export default App
