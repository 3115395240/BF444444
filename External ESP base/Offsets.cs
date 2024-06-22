/////////////XTREME HACK////////////////
///////////unknowncheats.me/////////////

using System;

namespace External_ESP_Base
{
    struct Offsets
    {
        public static Int64 OFFSET_DXRENDERER = 0x142572FA0;
        public static Int64 OFFSET_GAMECONTEXT = 0x1424abd20;
        public static Int64 OFFSET_GAMERENDERER = 0x1424AD330;
        public static Int64 OFFSET_VIEWANGLES = 0x1421caee0;
        public static Int64 OFFSET_MAIN = 0x14219ff68;
        public static Int64 OFFSET_CURRENT_WEAPONFIRING = OFFSET_VIEWANGLES + 0x8;
        public static Int64 OFFSET_BORDERINPUTNODE = 0x1424acf70;
        public static Int64 OFFSET_SHOTSTATS = 0x142572950;

        public struct ClientGameContext
        {
            public static Int64 m_pPhysicsManager = 0x28; // HavokPhysicsManager
            public static Int64 m_pPlayerManager = 0x60;  // ClientPlayerManager

            public static Int64 GetInstance()
            {
                return OFFSET_GAMECONTEXT;
            }
        }

        public struct ClientPlayerManager
        {
            public static Int64 m_pLocalPlayer = 0x540; // ClientPlayer
            public static Int64 m_ppPlayer = 0x548;     // ClientPlayer
        }

        public struct ClientPlayerView
        {
            public static Int64 m_Owner = 0x00F8; // ClientPlayer
        }

        public struct ClientPlayer
        {
            public static Int64 szName = 0x40;            // 10 CHARS
            public static Int64 m_isSpectator = 0x13C9;   // BYTE
            public static Int64 m_teamId = 0x13CC;        // INT32
            public static Int64 m_character = 0x14B0;     // ClientSoldierEntity 
            public static Int64 m_ownPlayerView = 0x1510; // ClientPlayerView
            public static Int64 m_PlayerView = 0x1520;    // ClientPlayerView
            public static Int64 m_pAttachedControllable = 0x14C0;   // ClientSoldierEntity (ClientVehicleEntity)
            public static Int64 m_pControlledControllable = 0x14D0; // ClientSoldierEntity
            public static Int64 m_attachedEntryId = 0x14C8; // INT32
        }

        public struct ClientVehicleEntity
        {
            public static Int64 m_data = 0x0030;           // VehicleEntityData
            public static Int64 m_pPhysicsEntity = 0x0238; // DynamicPhysicsEntity
            public static Int64 m_Velocity = 0x0280;       // D3DXVECTOR3 
            public static Int64 m_prevVelocity = 0x0290;   // D3DXVECTOR3 
            public static Int64 m_Chassis = 0x03E0;        // ClientChassisComponent
            public static Int64 m_childrenAABB = 0x0250;   // AxisAlignedBox
        }

        public struct AxisAlignedBox
        {
            public static Int64 m_Min = 0x00; // D3DXVECTOR3 
            public static Int64 m_Max = 0x10; // D3DXVECTOR3 
        }

        public struct DynamicPhysicsEntity
        {
            public static Int64 m_EntityTransform = 0xA0;  // PhysicsEntityTransform
        }

        public struct PhysicsEntityTransform
        {
            public static Int64 m_Transform = 0x00;       // D3DXMATRIX
        }

        public struct VehicleEntityData
        {
            public static Int64 m_FrontMaxHealth = 0x148; // FLOAT
            public static Int64 m_NameSid = 0x0248;       // char* ID_P_VNAME_9K22
        }

        public struct ClientChassisComponent
        {
            public static Int64 m_Velocity = 0x01C0; // D3DXVECTOR4
        }

        public struct ClientSoldierEntity
        {
            public static Int64 m_data = 0x0030;         // VehicleEntityData
            public static Int64 m_pPlayer = 0x01E0;          // ClientPlayer
            public static Int64 m_pHealthComponent = 0x0140; // HealthComponent
            public static Int64 m_authorativeYaw = 0x04D8;   // FLOAT
            public static Int64 m_authorativePitch = 0x04DC; // FLOAT 
            public static Int64 m_poseType = 0x04F0;         // INT32
            public static Int64 m_RenderFlags = 0x04F4;      // INT32
            public static Int64 m_pPhysicsEntity = 0x0238;   // VehicleDynamicPhysicsEntity
            public static Int64 m_pPredictedController = 0x0490;    // ClientSoldierPrediction
            public static Int64 m_soldierWeaponsComponent = 0x0570; // ClientSoldierWeaponsComponent
            public static Int64 m_ragdollComponent = 0x0580;        // ClientRagDollComponent 
            public static Int64 m_breathControlHandler = 0x0588;    // BreathControlHandler 
            public static Int64 m_sprinting = 0x5B0;  // BYTE 
            public static Int64 m_occluded = 0x05B1;  // BYTE
        }

        public struct HealthComponent
        {
            public static Int64 m_Health = 0x0020;        // FLOAT
            public static Int64 m_MaxHealth = 0x0024;     // FLOAT
            public static Int64 m_vehicleHealth = 0x0038; // FLOAT (pLocalSoldier + 0x1E0 + 0x14C0 + 0x140 + 0x38)
        }

        public struct ClientSoldierPrediction
        {
            public static Int64 m_Position = 0x0030; // D3DXVECTOR3
            public static Int64 m_Velocity = 0x0050; // D3DXVECTOR3
        }

        public struct ClientSoldierWeaponsComponent
        {
            public enum WeaponSlot
            {
                M_PRIMARY = 0,
                M_SECONDARY = 1,
                M_GADGET = 2,
                M_GRENADE = 6,
                M_KNIFE = 7
            };

            public static Int64 m_handler = 0x0890;      // m_handler + m_activeSlot * 0x8 = ClientSoldierWeapon
            public static Int64 m_activeSlot = 0x0A98;   // INT32 (WeaponSlot)
            public static Int64 m_activeHandler= 0x08D0; // ClientActiveWeaponHandler 
        }

        public struct UpdatePoseResultData
        {
            public enum BONES
            {
                BONE_HEAD = 104,
                BONE_NECK = 142,
                BONE_SPINE2 = 7,
                BONE_SPINE1 = 6,
                BONE_SPINE = 5,
                BONE_LEFTSHOULDER = 9,
                BONE_RIGHTSHOULDER = 109,
                BONE_LEFTELBOWROLL = 11,
                BONE_RIGHTELBOWROLL = 111,
                BONE_LEFTHAND = 15,
                BONE_RIGHTHAND = 115,
                BONE_LEFTKNEEROLL = 188,
                BONE_RIGHTKNEEROLL = 197,
                BONE_LEFTFOOT = 184,
                BONE_RIGHTFOOT = 198
            };

            public static Int64 m_ActiveWorldTransforms = 0x0028; // QuatTransform
            public static Int64 m_ValidTransforms = 0x0040;       // BYTE
        }

        public struct ClientRagDollComponent
        {
            public static Int64 m_ragdollTransforms = 0x0088; // UpdatePoseResultData
            public static Int64 m_Transform = 0x05D0;         // D3DXMATRIX
        }

        public struct QuatTransform
        {
            public static Int64 m_TransAndScale = 0x0000; // D3DXVECTOR4
            public static Int64 m_Rotation = 0x0010;      // D3DXVECTOR4
        }

        public struct ClientSoldierWeapon
        {
            public static Int64 m_data = 0x0030;              // WeaponEntityData
            public static Int64 m_authorativeAiming = 0x4988; // ClientSoldierAimingSimulation
            public static Int64 m_pWeapon = 0x49A8;           // ClientWeapon
            public static Int64 m_pPrimary = 0x49C0;          // WeaponFiring
        }

        public struct ClientActiveWeaponHandler
        {
            public static Int64 m_activeWeapon = 0x038; // ClientSoldierWeapon
        }

        public struct WeaponEntityData
        {
            public static Int64 m_name = 0x0130; // char*
        }

        public struct ClientSoldierAimingSimulation
        {
            public static Int64 m_fpsAimer = 0x0010;  // AimAssist
            public static Int64 m_yaw = 0x0018;       // FLOAT
            public static Int64 m_pitch = 0x001C;     // FLOAT
            public static Int64 m_sway = 0x0028;      // D3DXVECTOR2
            public static Int64 m_zoomLevel = 0x0068; // FLOAT
        }

        public struct ClientWeapon
        {
            public static Int64 m_pModifier =  0x0020; // WeaponModifier
            public static Int64 m_shootSpace = 0x0040; // D3DXMATRIX
        }

        public struct WeaponFiring
        {
            public static Int64 m_pSway = 0x0078;                  // WeaponSway
            public static Int64 m_pPrimaryFire = 0x0128;           // PrimaryFire 
            public static Int64 m_projectilesLoaded = 0x01A0;      // INT32 
            public static Int64 m_projectilesInMagazines = 0x01A4; // INT32 
            public static Int64 m_overheatPenaltyTimer = 0x01B0;   // FLOAT
        }

        public struct WeaponSway
        {
            public static Int64 m_pSwayData = 0x0008;      // GunSwayData
            public static Int64 m_deviationPitch = 0x0130; // FLOAT 
            public static Int64 m_deviationYaw = 0x0134;   // FLOAT 
        }

        public struct GunSwayData
        {
            public static Int64 m_DeviationScaleFactorZoom = 0x360;           // FLOAT 
            public static Int64 m_GameplayDeviationScaleFactorZoom = 0x364;   // FLOAT 
            public static Int64 m_DeviationScaleFactorNoZoom = 0x368;         // FLOAT 
            public static Int64 m_GameplayDeviationScaleFactorNoZoom = 0x36C; // FLOAT 

            public static Int64 m_ShootingRecoilDecreaseScale = 0x370; // FLOAT 
            public static Int64 m_FirstShotRecoilMultiplier = 0x374;   // FLOAT 
        }

        public struct PrimaryFire
        {
             public static Int64 m_shotConfigData = 0x0010; // ShotConfigData
        }

        public struct ShotConfigData
        {
            public static Int64 m_initialSpeed = 0x0088;    // FLOAT 
            public static Int64 m_pProjectileData = 0x00B0; // BulletEntityData
        }

        public struct BulletEntityData
        {
            public static Int64 m_Gravity = 0x0130;     // FLOAT
            public static Int64 m_StartDamage = 0x0154; // FLOAT
            public static Int64 m_EndDamage = 0x0158;   // FLOAT
        }

        public struct AimAssist
        {
            public static Int64 m_yaw = 0x0014;   // FLOAT
            public static Int64 m_pitch = 0x0018; // FLOAT
        }

        public struct BreathControlHandler
        {
            public static Int64 m_breathControlTimer = 0x0038; // FLOAT
            public static Int64 m_breathControlMultiplier = 0x003C; // FLOAT  
            public static Int64 m_breathControlPenaltyTimer = 0x0040; // FLOAT  
            public static Int64 m_breathControlpenaltyMultiplier = 0x0044; // FLOAT  
            public static Int64 m_breathControlActive = 0x0048; // FLOAT  
            public static Int64 m_breathControlInput = 0x004C; // FLOAT  
            public static Int64 m_breathActive = 0x0050; // FLOAT  
            public static Int64 m_Enabled = 0x0058; // FLOAT  
        }

        public struct GameRenderer
        {
            public static Int64 m_pRenderView = 0x60; // RenderView

            public static Int64 GetInstance()
            {
                return OFFSET_GAMERENDERER;
            }
        }

        public struct RenderView
        {
            public static Int64 m_Transform = 0x0040;         // D3DXMATRIX
            public static Int64 m_FovY = 0x00B4;              // FLOAT
            public static Int64 m_fovX = 0x0250;              // FLOAT
            public static Int64 m_ViewProj = 0x0420;          // D3DXMATRIX
            public static Int64 m_ViewMatrixInverse = 0x02E0; // D3DXMATRIX
            public static Int64 m_ViewProjInverse = 0x04A0;   // D3DXMATRIX
        }

        public struct BorderInputNode
        {
            public static Int64 m_pMouse = 0x0058; // Mouse
            public static Int64 GetInstance()
            {
                return OFFSET_BORDERINPUTNODE;
            }
        }

        public struct Mouse
        {
            public static Int64 m_pDevice = 0x0010; //  MouseDevice
        }

        public struct MouseDevice
        {
            public static Int64 m_Buffer = 0x0104; // D3DXVECTOR3
        }

        public struct VehicleWeapon
        {
            public static Int64 m_pClientCameraComponent = 0x0010; // ClientCameraComponent
            public static Int64 GetInstance()
            {
                return OFFSET_CURRENT_WEAPONFIRING;
            }
        }

        public struct ClientCameraComponent
        {
            public static Int64 pChaseorStaticCamera = 0x00B8; // StaticCamera
        }

        public struct StaticCamera
        {
            public static Int64 m_PreCrossMatrix = 0x0010;    // D3DXMATRIX
            public static Int64 m_CrossMatrix = 0x0050;       // D3DXMATRIX
            public static Int64 m_ForwardOffset = 0x01D0;     // D3DXVECTOR3
        }
    }
}
