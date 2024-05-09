import { Link } from "react-router-dom";
import React, { useState, useEffect } from 'react';
import axios from 'axios';

function PokemonCard({ pokemon }) {
  const [pokeData, setPokeData] = useState(null);

  useEffect(() => {
    const fetchData = async () => {
      try {
        const response = await axios.get(`http://localhost:5022/api/Pokemon/ByName/${pokemon}`);
        setPokeData(response.data);
      } catch (error) {
        console.log('ERROR: ', error);
      }
    };
    fetchData();
  }, [pokemon]);

  if(!pokeData){
    return(
      <div></div>
    )
  } else {
    return (
      <Link to={`/details/${pokemon.pokemon.name}`} style={{ textDecoration: 'none' }}>
        <div className="PokemonCard">
          <h6>{pokemon.pokemon.name.charAt(0).toUpperCase() + pokemon.pokemon.name.slice(1)}</h6>
          <span>#{pokemon.pokemon.order}</span>
          <img src={pokemon.pokemon.imgUrl} />
            <div  className='types'>
            {pokemon.types.map((type, index) => <Type key={index} type={type} />)}
            </div>
  
        </div>
      </Link>
    ); 
  }
}
  
const Type = ({type}) => {
    return (
      <div className={type.toLowerCase()}>
        <label>{type.charAt(0).toUpperCase() + type.slice(1)}</label>
      </div>
    );
} 
  
export default PokemonCard;