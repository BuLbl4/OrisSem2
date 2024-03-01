import './details.css'
import React, { useState, useEffect } from 'react';

import bug from '../../Types/Bug@2x.png'
import dark from '../../Types/Dark@2x.png'
import dragon from '../../Types/Dragon@2x.png'
import electric from '../../Types/Electric@2x.png'
import fairy from '../../Types/Fairy@2x.png'
import fight from '../../Types/Fight@2x.png'
import fire from '../../Types/Fire@2x.png'
import flying from '../../Types/Flying@2x.png'
import ghost from '../../Types/Ghost@2x.png'
import grass from '../../Types/Grass@2x.png'
import ground from '../../Types/Ground@2x.png'
import ice from '../../Types/Ice@2x.png'
import normal from '../../Types/Normal@2x.png'
import poison from '../../Types/Poison@2x.png'
import psychic from '../../Types/Psychic@2x.png'
import rock from '../../Types/Rock@2x.png'
import steel from '../../Types/Steel@2x.png'
import water from '../../Types/Water@2x.png'




function TypeCard({typeName}) {
    const typesImages = {
        "bug": bug,
        "dark": dark,
        "dragon": dragon,
        "electric": electric,
        "fairy": fairy,
        "fighting": fight,
        "fire": fire,
        "flying": flying,
        "ghost": ghost,
        "grass": grass,
        "ground": ground,
        "ice": ice,
        "normal": normal,
        "poison": poison,
        "psychic": psychic,
        "rock": rock,
        "steel": steel,
        "water": water
    };
    const [moveType, setMoveType] = useState(null);

    useEffect(() => {
        fetch(`https://pokeapi.co/api/v2/move/${typeName}`)
            .then(response => response.json())
            .then(moveType => {
                setMoveType(moveType);
            });
    }, [typeName]);


    if(!moveType){
        return(
            <div>
            </div>
        )
    } else {
        const nameSplit = moveType.name.split('-');
        const name = nameSplit.map(word => word.charAt(0).toUpperCase() + word.slice(1)).join(' ');
        return (
            <>
                <div className={`move ${moveType.type.name}-moves`}>
                    <div className='statis'>
                    <img alt={moveType.type.name} src={typesImages[`${moveType.type.name}`]} /> 
                        <span>{name}</span>
                    </div>
                </div>
            </>
        );    
    }
}


export default TypeCard;