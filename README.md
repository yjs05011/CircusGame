# CircusGame

issue: 
    - 모바일 해상도가 알맞게 나오지 않는 이슈 (2023-02-01)
    - objpooling 이 제대로 동작 하지 않는 이슈(2023-02-02)
    - 블루 원숭이가 점프를 하지 않는 이슈(2023-02-05)
summury: 
    - 모바일 해상도에 맞게 나오도록 canvas를 이용해 제작 했지만 폰트 크기 
    및 특정 문제들로 인해 제대로 출력이 되지 않는 문제(2023-02-01)
    - objpooling으로 생성된 장애물의 좌표가 제대로 원하는 위치에서 나오지 않는 문제(2023-02-02)
    - objpooling으로 생성된 장애물의 속도가 메인 카메라 이동에 따라 속도가 달라지는 문제(2023-02-03)
    - 블루 원숭이가 트리거 작동 후 점프를 해야하지만 하지 않는 문제(2023-02-05)

solve: 
    - canvas 의 텍스트 크기 조정 및 직접 좌표 설정이 아닌 앵커를 이용해 해상도를 맞췄음, 통상적 사용되는 스마트폰 해상도에 모두 적용됨을 확인. (2023-02-02)
    
    - objpooling으로 생성된 오브젝트를 부모 오브젝트에 넣는 과정에서 position이슈가 생긴 것으로 확인되어 새로운 오브젝트 생성 후 그 밑에 생성되도록 한 후 world포지션으로 자리를 배정하도록 해결(2023-02-03)

    - 생성된 장애물의 포지션이 canvas에 할당 되어서 카메라 이동 한 만큼 오브젝트의 좌표 또한 변함을 확인하였다. canvas밖에 gameobj에 상속시켜 해결(2023-02-03)

Circus // 0.0.1 ver // 2023-01-31

Circus // 0.0.2 ver // 2023-01-31 // make main_Ui

Circus // 0.1.0 ver // 2023-02-02 // make player And Background

Circus // 0.2.0 ver // 2023-02-02 // making 1 stage and Debug

Circus // 1.0.0 ver // 2023-02-03 // prototyping End, doing Debug 

Circus // 1.0.1 ver // 2023-02-05 // create blue monkey, doing Debug
