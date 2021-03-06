using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VCSLogViewer
{
    public enum ThemeColor
    {
        Default,
        Dark1,
        Dark2
    }

    public enum DI96
    {
        DI_0, DI_1, DI_2, DI_3, DI_4, DI_5, DI_6, DI_7, DI_8, DI_9,
        DI_10, DI_11, DI_12, DI_13, DI_14, DI_15, DI_16, DI_17, DI_18, DI_19,
        DI_20, DI_21, DI_22, DI_23, DI_24, DI_25, DI_26, DI_27, DI_28, DI_29,
        DI_30, DI_31, DI_32, DI_33, DI_34, DI_35, DI_36, DI_37, DI_38, DI_39,
        DI_40, DI_41, DI_42, DI_43, DI_44, DI_45, DI_46, DI_47, DI_48, DI_49,
        DI_50, DI_51, DI_52, DI_53, DI_54, DI_55, DI_56, DI_57, DI_58, DI_59,
        DI_60, DI_61, DI_62, DI_63, DI_64, DI_65, DI_66, DI_67, DI_68, DI_69,
        DI_70, DI_71, DI_72, DI_73, DI_74, DI_75, DI_76, DI_77, DI_78, DI_79,
        DI_80, DI_81, DI_82, DI_83, DI_84, DI_85, DI_86, DI_87, DI_88, DI_89,
        DI_90, DI_91, DI_92, DI_93, DI_94, DI_95
    }

    public enum DO96
    {
        DO_0, DO_1, DO_2, DO_3, DO_4, DO_5, DO_6, DO_7, DO_8, DO_9,
        DO_10, DO_11, DO_12, DO_13, DO_14, DO_15, DO_16, DO_17, DO_18, DO_19,
        DO_20, DO_21, DO_22, DO_23, DO_24, DO_25, DO_26, DO_27, DO_28, DO_29,
        DO_30, DO_31, DO_32, DO_33, DO_34, DO_35, DO_36, DO_37, DO_38, DO_39,
        DO_40, DO_41, DO_42, DO_43, DO_44, DO_45, DO_46, DO_47, DO_48, DO_49,
        DO_50, DO_51, DO_52, DO_53, DO_54, DO_55, DO_56, DO_57, DO_58, DO_59,
        DO_60, DO_61, DO_62, DO_63, DO_64, DO_65, DO_66, DO_67, DO_68, DO_69,
        DO_70, DO_71, DO_72, DO_73, DO_74, DO_75, DO_76, DO_77, DO_78, DO_79,
        DO_80, DO_81, DO_82, DO_83, DO_84, DO_85, DO_86, DO_87, DO_88, DO_89,
        DO_90, DO_91, DO_92, DO_93, DO_94, DO_95
    }

    public enum CMZ_INPUT_CHJS
    {
        UBG01_DETECT_01,
        UBG01_DETECT_02,
        UBG01_DETECT_03,
        UBG01_DETECT_04,
        UBG02_DETECT_01,
        UBG02_DETECT_02,
        UBG02_DETECT_03,
        UBG02_DETECT_04,
        LOOKDOWN_DETECT_01,
        LOOKDOWN_DETECT_02,
        LOOKDOWN_DETECT_03,
        LOOKDOWN_DETECT_04,
        BUMPER_OK,
        BUMPER_Alarm,
        EMO_SWITCH,
        DI_15,

        STEER_FRONT_LEFT,
        STEER_FRONT_RIGHT,
        DI_18,
        SYSTEM_DRV_STOP,
        TRANS_DRV_DET,
        TRANS_DRV_STOP,
        ANTIDROP_FRONT_LOCK,
        ANTIDROP_FRONT_UNLOCK,
        OUTRIGGER_FRONT_LOCK,
        OUTRIGGER_FRONT_UNLOCK,
        DI_26,
        SLIDE_HOME,
        DI_28,
        FOUP_DET,
        SWING_DETECT,
        HOIST_HOME,

        PCOM_1_POSITION,
        PCOM_2_STEP_ERROR,
        PCOM_3_LEFT_FLANGE,
        PCOM_4_RIGHT_FLANGE,
        PCOM_5_GRIP,
        PCOM_6_UNGRIP,
        PCOM_7_PUSHER,
        PCOM_8_,
        PCOM_ES,
        PCOM_STEP_GO,
        ZCU_01,
        ZCU_02,
        ZCU_03,
        ZCU_04,
        ZCU_05,
        ZCU_06,

        STEER_REAR_LEFT,
        STEER_REAR_RIGHT,
        ANTIDROP_REAR_LOCK,
        ANTIDROP_REAR_UNLOCK,
        OUTRIGGER_REAR_LOCK,
        OUTRIGGER_REAR_UNLOCK,
        DI_54,
        DI_55,
        FOUP_OPEN_DETECT,
        STB_LEFT_DET,
        DI_58,
        DI_59,
        DI_60,
        DI_62,
        DI_63,
        DI_64,

        EQ_PIO_1_L_REQ,
        EQ_PIO_2_U_REQ,
        EQ_PIO_3,
        EQ_PIO_4_READY,
        EQ_PIO_5,
        EQ_PIO_6,
        EQ_PIO_7_HO_AVBL,
        EQ_PIO_8_ES,
        EQ_PIO_9_PIO_GO,
        DI_73,
        DI_74,
        DI_75,
        DI_76,
        DI_77,
        DI_78,
        DI_79
    }

    public enum CMZ_OUTPUT_CHJS
    {
        DO_0,
        BRAKE_DRIVE,
        BRAKE_HOIST,
        MAIN_MC,
        UBG01_AREA_01,
        UBG01_AREA_02,
        UBG01_AREA_03,
        UBG01_AREA_04,
        UBG02_AREA_01,
        UBG02_AREA_02,
        UBG02_AREA_03,
        UBG02_AREA_04,
        LOOKDOWN_AREA_01,
        LOOKDOWN_AREA_02,
        LOOKDOWN_AREA_03,
        LOOKDOWN_AREA_04,

        STEER_FRONT_LEFT,
        STEER_FRONT_RIGHT,
        STEER_REAR_LEFT,
        STEER_REAR_RIGHT,
        TRACTION_STEER_FRONT_LEFT,
        TRACTION_STEER_FRONT_RIGHT,
        TRACTION_STEER_REAR_LEFT,
        TRACTION_STEER_REAR_RIGHT,

        ANTIDROP_START,
        ANTIDROP_CW_CCW,
        OUTRIGGER_FRONT_START,
        OUTRIGGER_FRONT_CW_CCW,
        DO_28,
        DO_29,
        DO_30,
        DO_31,
        ZCU_01,
        ZCU_02,
        ZCU_03,
        ZCU_04,
        ZCU_05,
        ZCU_06,
        DO_38,
        DO_39,

        PCOM_01_GRIP,
        PCOM_02_UNGRIP,
        PCOM_03_HOME,
        PCOM_04_RESET,
        PCOM_05_FREE,
        PCOM_06_CBRK_RELEASE,
        PCOM_07_TEACHING,
        PCOM_08,
        PCOM_TRIGGER,
        PCOM_SELECT,
        PCOM_MODE,
        DO_51,
        DO_52,
        DO_53,
        DO_54,
        DO_55,

        LED_LAMP_RED,
        LED_LAMP_GREEN,
        LED_LAMP_BLUE,
        BUZZER_1,
        BUZZER_2,
        BUZZER_3,
        BUZZER_4,
        DO_63,
        ANTIDROP_REAR_START,
        ANTIDROP_REAR_CW_CCW,
        OUTRIGGER_REAR_START,
        OUTRIGGER_REAR_CW_CCW,
        DO_68,
        BUMPER_RESET,
        DO_70,
        DO_71,

        EQ_PIO_01_VALID,
        EQ_PIO_02_CS,
        EQ_PIO_03,
        EQ_PIO_04,
        EQ_PIO_05_TR_REQ,
        EQ_PIO_06_BUSY,
        EQ_PIO_07_COMPT,
        EQ_PIO_08,
        EQ_PIO_09_SELECT,
        DO_81,
        DO_82,
        DO_83,
        DO_84,
        DO_85,
        DO_86,
        DO_87
    }

    public enum CMZ_INPUT_WUXI
    {
        UBG01_DETECT_01,
        UBG01_DETECT_02,
        UBG01_DETECT_03,
        UBG01_DETECT_04,
        UBG02_DETECT_01,
        UBG02_DETECT_02,
        UBG02_DETECT_03,
        UBG02_DETECT_04,
        LOOKDOWN_DETECT_01,
        LOOKDOWN_DETECT_02,
        LOOKDOWN_DETECT_03,
        LOOKDOWN_DETECT_04,
        BUMPER_OK,
        BUMPER_Alarm,
        EMO_SWITCH,
        DI_15,
        STEER_FRONT_LEFT,
        STEER_FRONT_RIGHT,
        DI_18,
        SYSTEM_DRV_STOP,
        DI_20,
        DI_21,
        ANTIDROP_F_LOCK,
        ANTIDROP_F_UNLOCK,
        DI_24,
        DI_25,
        DI_26,
        SLIDE_HOME,
        DI_28,
        FOUP_DET,
        SWING_DETECT,
        HOIST_HOME,
        PCOM_1_POSITION,
        PCOM_2_STEP_ERROR,
        PCOM_3_LEFT_FLANGE,
        PCOM_4_RIGHT_FLANGE,
        PCOM_5_GRIP,
        PCOM_6_UNGRIP,
        PCOM_7_PUSHER,
        PCOM_8_,
        PCOM_ES,
        PCOM_STEP_GO,
        DI_42,
        DI_43,
        DI_44,
        DI_45,
        DI_46,
        DI_47,
        STEER_REAR_LEFT,
        STEER_REAR_RIGHT,
        ANTIDROP_R_LOCK,
        ANTIDROP_R_UNLOCK,
        DI_52,
        DI_53,
        DI_54,
        DI_55,
        DI_56,
        DI_57,
        DI_58,
        DI_59,
        EQ_QR_DETECT,
        DI_61,
        DI_62,
        DI_63,
        EQ_PIO_1_L_REQ,
        EQ_PIO_2_U_REQ,
        EQ_PIO_3,
        EQ_PIO_4_READY,
        EQ_PIO_5,
        EQ_PIO_6,
        EQ_PIO_7_HO_AVBL,
        EQ_PIO_8_ES,
        EQ_PIO_9_PIO_GO,
        DI_73,
        DI_74,
        DI_75,
        DI_76,
        DI_77,
        DI_78,
        DI_79,
        ROTATE_PLUS_LIMIT,
        ROTATE_HOME,
        ROTATE_MINUS_LIMIT
    }

    public enum CMZ_OUTPUT_WUXI
    {
        DO_0,
        BRAKE_DRIVE,
        BRAKE_HOIST,
        MAIN_MC,
        UBG01_AREA_01,
        UBG01_AREA_02,
        UBG01_AREA_03,
        UBG01_AREA_04,
        UBG02_AREA_01,
        UBG02_AREA_02,
        UBG02_AREA_03,
        UBG02_AREA_04,
        LOOKDOWN_AREA_01,
        LOOKDOWN_AREA_02,
        LOOKDOWN_AREA_03,
        LOOKDOWN_AREA_04,
        STEER_FRONT_LEFT,
        STEER_FRONT_RIGHT,
        STEER_REAR_LEFT,
        STEER_REAR_RIGHT,
        DO_20,
        DO_21,
        DO_22,
        DO_23,
        DO_24,
        DO_25,
        DO_26,
        DO_27,
        DO_28,
        DO_29,
        DO_30,
        DO_31,
        DO_32,
        DO_33,
        DO_34,
        DO_35,
        DO_36,
        DO_37,
        DO_38,
        DO_39,
        PCOM_01_GRIP,
        PCOM_02_UNGRIP,
        PCOM_03_HOME,
        PCOM_04_RESET,
        PCOM_05_FREE,
        PCOM_06_CBRK_RELEASE,
        PCOM_07_TEACHING,
        PCOM_08,
        PCOM_TRIGGER,
        PCOM_SELECT,
        PCOM_MODE,
        DO_51,
        DO_52,
        DO_53,
        DO_54,
        DO_55,
        REAR_LED_LAMP_RED,
        REAR_LED_LAMP_GREEN,
        REAR_LED_LAMP_BLUE,
        BUZZER_1,
        BUZZER_2,
        BUZZER_3,
        BUZZER_4,
        DO_63,
        DO_64,
        DO_65,
        DO_66,
        DO_67,
        DO_68,
        BUMPER_RESET,
        DO_70,
        DO_71,
        EQ_PIO_01_VALID,
        EQ_PIO_02_CS,
        EQ_PIO_03_CS_11,
        EQ_PIO_04,
        EQ_PIO_05_TR_REQ,
        EQ_PIO_06_BUSY,
        EQ_PIO_07_COMPT,
        EQ_PIO_08_CONT,
        EQ_PIO_09_SELECT,
        DO_81,
        DO_82,
        DO_83,
        DO_84,
        DO_85,
        DO_86,
        DO_87
    }

    public enum CMZ_INPUT_SKS
    {
        UBG_DETECT_1,
        UBG_DETECT_2,
        UBG_DETECT_3,
        UBG_DETECT_4,
        UBG2_DETECT_1,
        UBG2_DETECT_2,
        UBG2_DETECT_3,
        UBG2_DETECT_4,
        LOOKDOWN_1,
        LOOKDOWN_2,
        LOOKDOWN_3,
        LOOKDOWN_4,
        BUMPER_OK,
        BUMPER_ALARM,
        EMO_SW,
        IP_15,

        // IO MOUDLE 1
        STEER_FRONT_LEFT,
        STEER_FRONT_RIGHT,
        IP_18,
        SYSTEM_DRV_STOP,
        IP_20,
        IP_21,
        ANTIDROP_FRONT_LOCK,
        ANTIDROP_FRONT_UNLOCK,
        IP_24,
        IP_25,
        IP_26,
        SLIDE_HOME,
        IP_28,
        FOUP_DET,
        SWING_DETECT,
        HOIST_HOME,

        // IO MODULE 2
        PCOM_1_POSITION,
        PCOM_2_STEP_ERROR,
        PCOM_3_LEFT_FLANGE,
        PCOM_4_RIGHT_FLANGE,
        PCOM_5_GRIP,
        PCOM_6_UNGRIP,
        PCOM_7_PUSHER,
        PCOM_8_,
        PCOM_ES,
        PCOM_STEP_GO,
        IP_42,
        IP_43,
        IP_44,
        IP_45,
        IP_46,
        IP_47,

        // IO MODULE 3
        STEER_REAR_LEFT,
        STEER_REAR_RIGHT,
        ANTIDROP_REAR_LOCK,
        ANTIDROP_REAR_UNLOCK,
        IP_52,
        IP_53,
        IP_54,
        IP_55,
        QR_DETECT,
        IP_57,
        ZCU_LINK_COMP,
        ZCU_STATUS,
        ZCU_PERMIT,
        ZCU_04,
        ZCU_05,
        ZCU_06,

        // IO MODULE 4
        EQ_PIO_1_L_REQ,
        EQ_PIO_2_U_REQ,
        EQ_PIO_3,
        EQ_PIO_4_READY,
        EQ_PIO_5,
        EQ_PIO_6,
        EQ_PIO_7_HO_AVBL,
        EQ_PIO_8_ES,
        EQ_PIO_9_PIO_GO,
        IP_73,
        IP_74,
        IP_75,
        IP_76,
        IP_77,
        IP_78,
        IP_79,
        ROTATE_PLUS_LIMIT,
        ROTATE_HOME,
        ROTATE_MINUS_LIMIT
    }

    public enum CMZ_OUTPUT_SKS
    {
        OP_0,
        RELEASE_BRAKE_DRIVE,
        RELEASE_BRAKE_HOIST,
        MAIN_MC,
        UBG01_AREA_01,
        UBG01_AREA_02,
        UBG01_AREA_03,
        UBG01_AREA_04,
        UBG02_AREA_01,
        UBG02_AREA_02,
        UBG02_AREA_03,
        UBG02_AREA_04,
        LOOKDOWN_AREA_01,
        LOOKDOWN_AREA_02,
        LOOKDOWN_AREA_03,
        LOOKDOWN_AREA_04,

        // SOL 
        STEER_FRONT_LEFT,
        STEER_FRONT_RIGHT,
        STEER_REAR_LEFT,
        STEER_REAR_RIGHT,
        OP_20,
        OP_21,
        OP_22,
        OP_23,

        // IO MOUDLE 1-1
        OP_24,
        OP_25,
        OP_26,
        OP_27,
        OP_28,
        OP_29,
        OP_30,
        OP_31,
        LED_LAMP_RED,
        LED_LAMP_GREEN,
        LED_LAMP_BLUE,
        BUZZER_1,
        BUZZER_2,
        BUZZER_3,
        BUZZER_4,
        OP_39,

        // IO MOUDLE 2-1
        PCOM_01_GRIP,
        PCOM_02_UNGRIP,
        PCOM_03_HOME,
        PCOM_04_RESET,
        PCOM_05_FREE,
        PCOM_06_CBRK_RELEASE,
        PCOM_07_TEACHING,
        PCOM_08,
        OP_48,
        OP_49,
        OP_50,
        OP_51,
        OP_52,
        OP_53,
        OP_54,
        PCOM_TRIGGER,

        // IO MOUDLE 3-1
        OP_56,
        OP_57,
        OP_58,
        OP_59,
        OP_60,
        BUMPER_RESET,
        OP_62,
        OP_63,
        OP_64,
        ZCU_USE,
        ZCU_JOIN_1,
        ZCU_JOIN_2,
        ZCU_PASS,
        ZCU_05,
        ZCU_06,
        OP_71,

        // IO MOUDLE 4-1
        EQ_PIO_01_VALID,
        EQ_PIO_02_CS,
        EQ_PIO_03,
        EQ_PIO_04,
        EQ_PIO_05_TR_REQ,
        EQ_PIO_06_BUSY,
        EQ_PIO_07_COMPT,
        EQ_PIO_08,
        EQ_PIO_09_SELECT,
        OP_81,
        OP_82,
        OP_83,
        OP_84,
        OP_85,
        OP_86,
        OP_87,
    }

    public enum CMZ_INPUT_SKI_POLAND
    {
        UBG01_DETECT_01,
        UBG01_DETECT_02,
        UBG01_DETECT_03,
        UBG01_DETECT_04,
        DI_04,
        DI_05,
        DI_06,
        DI_07,
        DI_08,
        DI_09,
        DI_10,
        DI_11,
        BUMPER_OK,
        BUMPER_Alarm,
        EMO_SWITCH,
        DI_15,

        STEER_FRONT_LEFT,
        STEER_FRONT_RIGHT,
        DI_18,
        TRANS_DECEL,
        DI_20,
        TRANS_STOP,
        PCOM_IN_ES,
        PCOM_IN_STEP_GO,
        DI_24,
        DI_25,
        DI_26,
        DI_27,
        DI_28,
        DI_29,
        SWING_DETECT,
        HOIST_HOME,

        PCOM_1_GRIP_FRONT_MOVE_POS1,
        PCOM_2_GRIP_FRONT_MOVE_POS2,
        PCOM_3_GRIP_FRONT_MOVE_POS3,
        PCOM_4_GRIP_REAR_MOVE_POS1,
        PCOM_5_GRIP_REAR_MOVE_POS2,
        PCOM_6_GRIP_REAR_MOVE_POS3,
        DI_38,
        PCOM_8_GRIP_FRONT_HOME,
        PCOM_9_GRIP_REAR_HOME,
        PCOM_10_FRONT_CARRIER_EXIST,
        PCOM_11_REAR_CARRIER_EXIST,
        PCOM_12_FRONT_MOVE_END,
        PCOM_13_REAR_MOVE_END,
        PCOM_14_FRONT_GRIPPER_ALARM,
        PCOM_15_REAR_GRIPPER_ALARM,
        DI_47,

        STEER_REAR_LEFT,
        STEER_REAR_RIGHT,
        DI_50,
        DI_51,
        DI_52,
        DI_53,
        DI_54,
        DI_55,
        DI_56,
        DI_57,
        ZCU_LINK_COMP,
        ZCU_STATUS,
        ZCU_PERMIT,
        ZCU_04_SPARE,
        ZCU_05_SPARE,
        ZCU_06_SPARE,

        EQ_PIO_1_L_REQ,
        EQ_PIO_2_U_REQ,
        EQ_PIO_3,
        EQ_PIO_4_READY,
        EQ_PIO_5,
        EQ_PIO_6,
        EQ_PIO_7_HO_AVBL,
        EQ_PIO_8_ES,
        EQ_PIO_9_PIO_GO,
        DI_73,
        DI_74,
        DI_75,
        DI_76,
        DI_77,
        DI_78,
        DI_79
    }

    public enum CMZ_OUTPUT_SKI_POLAND
    {
        DO_0,
        BRAKE_DRIVE,
        BRAKE_HOIST,
        MAIN_MC,
        UBG01_AREA_01,
        UBG01_AREA_02,
        UBG01_AREA_03,
        UBG01_AREA_04,
        DO_8,
        DO_9,
        DO_10,
        DO_11,
        DO_12,
        DO_13,
        DO_14,
        DO_15,

        DO_16,
        DO_17,
        DO_18,
        DO_19,

        DO_20,
        DO_21,
        DO_22,
        DO_23,

        DO_24,
        DO_25,
        DO_26,
        DO_27,
        DO_28,
        DO_29,
        DO_30,
        DO_31,
        LED_LAMP_RED,
        LED_LAMP_GREEN,
        LED_LAMP_BLUE,
        BUZZER_1,
        BUZZER_2,
        BUZZER_3,
        BUZZER_4,
        DO_39,

        PCOM_01_GRIP_FRONT_SEL,
        PCOM_02_GRIP_REAR_SEL,
        PCOM_03_GRIP_ALARM_RESET,
        PCOM_04_GRIP_PT_START,
        PCOM_05_GRIP_MOVE_JOB_BIT0,
        PCOM_06_GRIP_MOVE_JOB_BIT1,
        PCOM_07_GRIP_MOVE_JOB_BIT2,
        PCOM_08_GRIP_MOVE_JOB_BIT3,
        PCOM_09_GRIP_FRONT_BRK_RELEASE,
        PCOM_10_GRIP_REAR_BRK_RELEASE,
        DO_50,
        DO_51,
        DO_52,
        DO_53,
        DO_54,
        PCOM_TRIGGER,


        DO_56,
        DO_57,
        DO_58,
        DO_59,
        SAFETY_RESET,
        BUMPER_RESET,
        DO_62,
        DO_63,
        DO_64,
        ZCU_USE,
        ZUC_JOIN_PATH_1,
        ZUC_JOIN_PATH_2,
        ZCU_PASS,
        ZCU_05_SPARE,
        ZCU_06_SPARE,
        DO_71,


        EQ_PIO_01_VALID,
        EQ_PIO_02_CS,
        EQ_PIO_03,
        EQ_PIO_04,
        EQ_PIO_05_TR_REQ,
        EQ_PIO_06_BUSY,
        EQ_PIO_07_COMPT,
        EQ_PIO_08,
        EQ_PIO_09_SELECT,
        DO_81,
        DO_82,
        DO_83,
        DO_84,
        DO_85,
        DO_86,
        DO_87
    }
}
