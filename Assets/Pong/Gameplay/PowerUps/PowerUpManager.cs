using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour {

    public enum PowerUpMode {

        everything,
        all_positive,
        all_negative,
        all_paddle_powerups,
        all_ball_powerups,
        all_level_powerups,
        all_player_powerups,
        only_bigger_paddle,
        only_faster_paddle,
        only_ball_clone,
        only_penetrating,
        only_aoe_damage,
        only_sniper_ball,
        only_electro_ball,
        only_bigger_ball,
        only_faster_ball,
        only_scorepoints_1000,
        only_extra_life,
        only_safe_floor,
        only_pacman,
        //only_rockets,
        //only_freezetime,
        only_smaller_paddle,
        only_slower_paddle,
        only_smaller_ball,
        only_slower_ball,
        only_invisible_ball,
        only_invisible__bricks,
        only_blackhole,
        only_enemy_player,
        only_reverse_control,
        only_brick_respawn
    }
    public PowerUpMode powerUpMode;

    [Range(0.0f,1.0f)]
    public float spawnChance;

    public GameObject[] possiblePowerUps;
    public List<GameObject> choosenPowerUps;

    void Start() {
        switch (powerUpMode) {
            case PowerUpMode.everything:
                for (int i = 0; i < (possiblePowerUps.Length - 2); i++) {

                    choosenPowerUps.Add(possiblePowerUps[i]);
                }
                break;
            case PowerUpMode.all_positive:
                choosenPowerUps.Add(possiblePowerUps[15]);
                choosenPowerUps.Add(possiblePowerUps[17]);
                choosenPowerUps.Add(possiblePowerUps[1]);
                choosenPowerUps.Add(possiblePowerUps[18]);
                choosenPowerUps.Add(possiblePowerUps[0]);
                choosenPowerUps.Add(possiblePowerUps[22]);
                choosenPowerUps.Add(possiblePowerUps[8]);
                choosenPowerUps.Add(possiblePowerUps[3]);
                choosenPowerUps.Add(possiblePowerUps[5]);
                choosenPowerUps.Add(possiblePowerUps[21]);
                choosenPowerUps.Add(possiblePowerUps[10]);
                choosenPowerUps.Add(possiblePowerUps[20]);
                choosenPowerUps.Add(possiblePowerUps[13]);
                //choosenPowerUps.Add(possiblePowerUps[23]);
                //choosenPowerUps.Add(possiblePowerUps[24]);
                break;
            case PowerUpMode.all_negative:
                choosenPowerUps.Add(possiblePowerUps[14]);
                choosenPowerUps.Add(possiblePowerUps[16]);
                choosenPowerUps.Add(possiblePowerUps[2]);
                choosenPowerUps.Add(possiblePowerUps[4]);
                choosenPowerUps.Add(possiblePowerUps[11]);
                choosenPowerUps.Add(possiblePowerUps[12]);
                choosenPowerUps.Add(possiblePowerUps[6]);
                choosenPowerUps.Add(possiblePowerUps[9]);
                choosenPowerUps.Add(possiblePowerUps[19]);
                break;
            case PowerUpMode.all_paddle_powerups:
                choosenPowerUps.Add(possiblePowerUps[15]);
                choosenPowerUps.Add(possiblePowerUps[17]);
                choosenPowerUps.Add(possiblePowerUps[14]);
                choosenPowerUps.Add(possiblePowerUps[16]);
                break;
            case PowerUpMode.all_ball_powerups:
                choosenPowerUps.Add(possiblePowerUps[1]);
                choosenPowerUps.Add(possiblePowerUps[18]);
                choosenPowerUps.Add(possiblePowerUps[0]);
                choosenPowerUps.Add(possiblePowerUps[22]);
                choosenPowerUps.Add(possiblePowerUps[8]);
                choosenPowerUps.Add(possiblePowerUps[3]);
                choosenPowerUps.Add(possiblePowerUps[5]);
                choosenPowerUps.Add(possiblePowerUps[2]);
                choosenPowerUps.Add(possiblePowerUps[4]);
                choosenPowerUps.Add(possiblePowerUps[11]);
                break;
            case PowerUpMode.all_level_powerups:
                choosenPowerUps.Add(possiblePowerUps[21]);
                choosenPowerUps.Add(possiblePowerUps[10]);
                choosenPowerUps.Add(possiblePowerUps[20]);
                choosenPowerUps.Add(possiblePowerUps[13]);
                choosenPowerUps.Add(possiblePowerUps[12]);
                choosenPowerUps.Add(possiblePowerUps[6]);
                choosenPowerUps.Add(possiblePowerUps[9]);
                choosenPowerUps.Add(possiblePowerUps[7]);
                break;
            case PowerUpMode.all_player_powerups:
                //choosenPowerUps.Add(possiblePowerUps[23]);
                //choosenPowerUps.Add(possiblePowerUps[24]);
                choosenPowerUps.Add(possiblePowerUps[19]);
                break;
            case PowerUpMode.only_bigger_paddle:
                choosenPowerUps.Add(possiblePowerUps[15]);
                break;
            case PowerUpMode.only_faster_paddle:
                choosenPowerUps.Add(possiblePowerUps[17]);
                break;
            case PowerUpMode.only_ball_clone:
                choosenPowerUps.Add(possiblePowerUps[1]);
                break;
            case PowerUpMode.only_penetrating:
                choosenPowerUps.Add(possiblePowerUps[18]);
                break;
            case PowerUpMode.only_aoe_damage:
                choosenPowerUps.Add(possiblePowerUps[0]);
                break;
            case PowerUpMode.only_sniper_ball:
                choosenPowerUps.Add(possiblePowerUps[22]);
                break;
            case PowerUpMode.only_electro_ball:
                choosenPowerUps.Add(possiblePowerUps[8]);
                break;
            case PowerUpMode.only_bigger_ball:
                choosenPowerUps.Add(possiblePowerUps[3]);
                break;
            case PowerUpMode.only_faster_ball:
                choosenPowerUps.Add(possiblePowerUps[5]);
                break;
            case PowerUpMode.only_scorepoints_1000:
                choosenPowerUps.Add(possiblePowerUps[21]);
                break;
            case PowerUpMode.only_extra_life:
                choosenPowerUps.Add(possiblePowerUps[10]);
                break;
            case PowerUpMode.only_safe_floor:
                choosenPowerUps.Add(possiblePowerUps[20]);
                break;
            case PowerUpMode.only_pacman:
                choosenPowerUps.Add(possiblePowerUps[13]);
                break;
            /*case PowerUpMode.only_rockets:
                choosenPowerUps.Add(possiblePowerUps[23]);
                break;*/
            /*case PowerUpMode.only_freezetime:
                choosenPowerUps.Add(possiblePowerUps[24]);
                break;*/
            case PowerUpMode.only_smaller_paddle:
                choosenPowerUps.Add(possiblePowerUps[14]);
                break;
            case PowerUpMode.only_slower_paddle:
                choosenPowerUps.Add(possiblePowerUps[16]);
                break;
            case PowerUpMode.only_smaller_ball:
                choosenPowerUps.Add(possiblePowerUps[2]);
                break;
            case PowerUpMode.only_slower_ball:
                choosenPowerUps.Add(possiblePowerUps[4]);
                break;
            case PowerUpMode.only_invisible_ball:
                choosenPowerUps.Add(possiblePowerUps[11]);
                break;
            case PowerUpMode.only_invisible__bricks:
                choosenPowerUps.Add(possiblePowerUps[12]);
                break;
            case PowerUpMode.only_blackhole:
                choosenPowerUps.Add(possiblePowerUps[6]);
                break;
            case PowerUpMode.only_enemy_player:
                choosenPowerUps.Add(possiblePowerUps[9]);
                break;
            case PowerUpMode.only_reverse_control:
                choosenPowerUps.Add(possiblePowerUps[19]);
                break;
            case PowerUpMode.only_brick_respawn:
                choosenPowerUps.Add(possiblePowerUps[7]);
                break;
            default:
                break;

        }
    }

    public void SpawnPowerUp(Vector2 brickPosition) {

        if(Random.Range(0.0f, 1.0f) <= spawnChance) {

            if(choosenPowerUps.Count == 1) {

                Instantiate(choosenPowerUps[0], brickPosition, Quaternion.identity);
            }else{

                Instantiate(choosenPowerUps[Random.Range(0, choosenPowerUps.Count)], brickPosition, Quaternion.identity);
            }
        }
    }
}
