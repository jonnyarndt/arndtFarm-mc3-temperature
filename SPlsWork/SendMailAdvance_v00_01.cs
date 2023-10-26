using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Linq;
using Crestron;
using Crestron.Logos.SplusLibrary;
using Crestron.Logos.SplusObjects;
using Crestron.SimplSharp;

namespace UserModule_SENDMAILADVANCE_V00_01
{
    public class UserModuleClass_SENDMAILADVANCE_V00_01 : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        Crestron.Logos.SplusObjects.DigitalInput SENDMAILADVANCETRIGGER;
        Crestron.Logos.SplusObjects.AnalogInput PORTNUMBER;
        Crestron.Logos.SplusObjects.StringInput SERVER__DOLLAR__;
        Crestron.Logos.SplusObjects.StringInput SENDERNAME__DOLLAR__;
        Crestron.Logos.SplusObjects.StringInput SENDERPASSWORD__DOLLAR__;
        Crestron.Logos.SplusObjects.StringInput FROM__DOLLAR__;
        Crestron.Logos.SplusObjects.StringInput TO__DOLLAR__;
        Crestron.Logos.SplusObjects.StringInput CC__DOLLAR__;
        Crestron.Logos.SplusObjects.StringInput SUBJECT__DOLLAR__;
        Crestron.Logos.SplusObjects.StringInput MESSAGE__DOLLAR__;
        Crestron.Logos.SplusObjects.StringInput ATTACHMENT__DOLLAR__;
        ushort ITEMP = 0;
        short SIGNEDINTEGERERROR = 0;
        object SENDMAILADVANCETRIGGER_OnPush_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 87;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( PORTNUMBER  .UshortValue <= 0 ) ) || Functions.TestForTrue ( Functions.BoolToInt ( PORTNUMBER  .UshortValue >= 65535 ) )) ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 89;
                    Trace( "PortNumber {0:d} value invalid, PortNumber", (short)PORTNUMBER  .UshortValue) ; 
                    __context__.SourceCodeLine = 90;
                    return  this ; 
                    } 
                
                __context__.SourceCodeLine = 93;
                ITEMP = (ushort) ( Functions.Length( SERVER__DOLLAR__ ) ) ; 
                __context__.SourceCodeLine = 94;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( ITEMP <= 2 ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 96;
                    Trace( "Server$ length {0:d} value invalir", (short)ITEMP) ; 
                    __context__.SourceCodeLine = 97;
                    return  this ; 
                    } 
                
                __context__.SourceCodeLine = 100;
                SIGNEDINTEGERERROR = (short) ( SendMailAdvance( SERVER__DOLLAR__ , (ushort)( PORTNUMBER  .ShortValue ) , SENDERNAME__DOLLAR__ , SENDERPASSWORD__DOLLAR__ , FROM__DOLLAR__ , TO__DOLLAR__ , CC__DOLLAR__ , SUBJECT__DOLLAR__ , MESSAGE__DOLLAR__ , (ushort)( 0 ) , ATTACHMENT__DOLLAR__ ) ) ; 
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    
    public override void LogosSplusInitialize()
    {
        SocketInfo __socketinfo__ = new SocketInfo( 1, this );
        InitialParametersClass.ResolveHostName = __socketinfo__.ResolveHostName;
        _SplusNVRAM = new SplusNVRAM( this );
        
        SENDMAILADVANCETRIGGER = new Crestron.Logos.SplusObjects.DigitalInput( SENDMAILADVANCETRIGGER__DigitalInput__, this );
        m_DigitalInputList.Add( SENDMAILADVANCETRIGGER__DigitalInput__, SENDMAILADVANCETRIGGER );
        
        PORTNUMBER = new Crestron.Logos.SplusObjects.AnalogInput( PORTNUMBER__AnalogSerialInput__, this );
        m_AnalogInputList.Add( PORTNUMBER__AnalogSerialInput__, PORTNUMBER );
        
        SERVER__DOLLAR__ = new Crestron.Logos.SplusObjects.StringInput( SERVER__DOLLAR____AnalogSerialInput__, 50, this );
        m_StringInputList.Add( SERVER__DOLLAR____AnalogSerialInput__, SERVER__DOLLAR__ );
        
        SENDERNAME__DOLLAR__ = new Crestron.Logos.SplusObjects.StringInput( SENDERNAME__DOLLAR____AnalogSerialInput__, 50, this );
        m_StringInputList.Add( SENDERNAME__DOLLAR____AnalogSerialInput__, SENDERNAME__DOLLAR__ );
        
        SENDERPASSWORD__DOLLAR__ = new Crestron.Logos.SplusObjects.StringInput( SENDERPASSWORD__DOLLAR____AnalogSerialInput__, 50, this );
        m_StringInputList.Add( SENDERPASSWORD__DOLLAR____AnalogSerialInput__, SENDERPASSWORD__DOLLAR__ );
        
        FROM__DOLLAR__ = new Crestron.Logos.SplusObjects.StringInput( FROM__DOLLAR____AnalogSerialInput__, 50, this );
        m_StringInputList.Add( FROM__DOLLAR____AnalogSerialInput__, FROM__DOLLAR__ );
        
        TO__DOLLAR__ = new Crestron.Logos.SplusObjects.StringInput( TO__DOLLAR____AnalogSerialInput__, 50, this );
        m_StringInputList.Add( TO__DOLLAR____AnalogSerialInput__, TO__DOLLAR__ );
        
        CC__DOLLAR__ = new Crestron.Logos.SplusObjects.StringInput( CC__DOLLAR____AnalogSerialInput__, 50, this );
        m_StringInputList.Add( CC__DOLLAR____AnalogSerialInput__, CC__DOLLAR__ );
        
        SUBJECT__DOLLAR__ = new Crestron.Logos.SplusObjects.StringInput( SUBJECT__DOLLAR____AnalogSerialInput__, 50, this );
        m_StringInputList.Add( SUBJECT__DOLLAR____AnalogSerialInput__, SUBJECT__DOLLAR__ );
        
        MESSAGE__DOLLAR__ = new Crestron.Logos.SplusObjects.StringInput( MESSAGE__DOLLAR____AnalogSerialInput__, 50, this );
        m_StringInputList.Add( MESSAGE__DOLLAR____AnalogSerialInput__, MESSAGE__DOLLAR__ );
        
        ATTACHMENT__DOLLAR__ = new Crestron.Logos.SplusObjects.StringInput( ATTACHMENT__DOLLAR____AnalogSerialInput__, 50, this );
        m_StringInputList.Add( ATTACHMENT__DOLLAR____AnalogSerialInput__, ATTACHMENT__DOLLAR__ );
        
        
        SENDMAILADVANCETRIGGER.OnDigitalPush.Add( new InputChangeHandlerWrapper( SENDMAILADVANCETRIGGER_OnPush_0, false ) );
        
        _SplusNVRAM.PopulateCustomAttributeList( true );
        
        NVRAM = _SplusNVRAM;
        
    }
    
    public override void LogosSimplSharpInitialize()
    {
        
        
    }
    
    public UserModuleClass_SENDMAILADVANCE_V00_01 ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}
    
    
    
    
    const uint SENDMAILADVANCETRIGGER__DigitalInput__ = 0;
    const uint PORTNUMBER__AnalogSerialInput__ = 0;
    const uint SERVER__DOLLAR____AnalogSerialInput__ = 1;
    const uint SENDERNAME__DOLLAR____AnalogSerialInput__ = 2;
    const uint SENDERPASSWORD__DOLLAR____AnalogSerialInput__ = 3;
    const uint FROM__DOLLAR____AnalogSerialInput__ = 4;
    const uint TO__DOLLAR____AnalogSerialInput__ = 5;
    const uint CC__DOLLAR____AnalogSerialInput__ = 6;
    const uint SUBJECT__DOLLAR____AnalogSerialInput__ = 7;
    const uint MESSAGE__DOLLAR____AnalogSerialInput__ = 8;
    const uint ATTACHMENT__DOLLAR____AnalogSerialInput__ = 9;
    
    [SplusStructAttribute(-1, true, false)]
    public class SplusNVRAM : SplusStructureBase
    {
    
        public SplusNVRAM( SplusObject __caller__ ) : base( __caller__ ) {}
        
        
    }
    
    SplusNVRAM _SplusNVRAM = null;
    
    public class __CEvent__ : CEvent
    {
        public __CEvent__() {}
        public void Close() { base.Close(); }
        public int Reset() { return base.Reset() ? 1 : 0; }
        public int Set() { return base.Set() ? 1 : 0; }
        public int Wait( int timeOutInMs ) { return base.Wait( timeOutInMs ) ? 1 : 0; }
    }
    public class __CMutex__ : CMutex
    {
        public __CMutex__() {}
        public void Close() { base.Close(); }
        public void ReleaseMutex() { base.ReleaseMutex(); }
        public int WaitForMutex() { return base.WaitForMutex() ? 1 : 0; }
    }
     public int IsNull( object obj ){ return (obj == null) ? 1 : 0; }
}


}
