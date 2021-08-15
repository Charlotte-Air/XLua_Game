#if USE_UNI_LUA
using LuaAPI = UniLua.Lua;
using RealStatePtr = UniLua.ILuaState;
using LuaCSFunction = UniLua.CSharpFunctionDelegate;
#else
using LuaAPI = XLua.LuaDLL.Lua;
using RealStatePtr = System.IntPtr;
using LuaCSFunction = XLua.LuaDLL.lua_CSFunction;
#endif

using XLua;
using System.Collections.Generic;


namespace XLua.CSObjectWrap
{
    using Utils = XLua.Utils;
    public class PublicWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(Public);
			Utils.BeginObjectRegister(type, L, translator, 0, 10, 15, 15);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "setXyInfo", _m_setXyInfo);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "moveMap", _m_moveMap);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "peopleJiaoHu", _m_peopleJiaoHu);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "peopleJiaoHuClose", _m_peopleJiaoHuClose);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "setChildObjOfCanvas", _m_setChildObjOfCanvas);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "showLoadScene", _m_showLoadScene);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "closeLoadScene", _m_closeLoadScene);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "cameraPosInit", _m_cameraPosInit);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ShowXiTongChat_o", _m_ShowXiTongChat_o);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "getType", _m_getType);
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "isGuide", _g_get_isGuide);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "canvas", _g_get_canvas);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "canvasLoad", _g_get_canvasLoad);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "TextDrama", _g_get_TextDrama);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "fightAnimation", _g_get_fightAnimation);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "settlement", _g_get_settlement);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "SaveMoldState", _g_get_SaveMoldState);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "Xend1", _g_get_Xend1);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "Xegde1", _g_get_Xegde1);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "Yend1", _g_get_Yend1);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "Yegde1", _g_get_Yegde1);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "Xend2", _g_get_Xend2);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "Xegde2", _g_get_Xegde2);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "Yend2", _g_get_Yend2);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "Yegde2", _g_get_Yegde2);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "isGuide", _s_set_isGuide);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "canvas", _s_set_canvas);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "canvasLoad", _s_set_canvasLoad);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "TextDrama", _s_set_TextDrama);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "fightAnimation", _s_set_fightAnimation);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "settlement", _s_set_settlement);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "SaveMoldState", _s_set_SaveMoldState);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "Xend1", _s_set_Xend1);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "Xegde1", _s_set_Xegde1);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "Yend1", _s_set_Yend1);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "Yegde1", _s_set_Yegde1);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "Xend2", _s_set_Xend2);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "Xegde2", _s_set_Xegde2);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "Yend2", _s_set_Yend2);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "Yegde2", _s_set_Yegde2);
            
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 1, 1, 1);
			
			
            
			Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "instance", _g_get_instance);
            
			Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "instance", _s_set_instance);
            
			
			Utils.EndClassRegister(type, L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					Public gen_ret = new Public();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to Public constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_setXyInfo(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Public gen_to_be_invoked = (Public)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    float _Xend1 = (float)LuaAPI.lua_tonumber(L, 2);
                    float _Xegde1 = (float)LuaAPI.lua_tonumber(L, 3);
                    float _Yend1 = (float)LuaAPI.lua_tonumber(L, 4);
                    float _Yegde1 = (float)LuaAPI.lua_tonumber(L, 5);
                    float _Xend2 = (float)LuaAPI.lua_tonumber(L, 6);
                    float _Xegde2 = (float)LuaAPI.lua_tonumber(L, 7);
                    float _Yend2 = (float)LuaAPI.lua_tonumber(L, 8);
                    float _Yegde2 = (float)LuaAPI.lua_tonumber(L, 9);
                    
                    gen_to_be_invoked.setXyInfo( _Xend1, _Xegde1, _Yend1, _Yegde1, _Xend2, _Xegde2, _Yend2, _Yegde2 );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_moveMap(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Public gen_to_be_invoked = (Public)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string _nowmap = LuaAPI.lua_tostring(L, 2);
                    string _nowmapid = LuaAPI.lua_tostring(L, 3);
                    float _x = (float)LuaAPI.lua_tonumber(L, 4);
                    float _y = (float)LuaAPI.lua_tonumber(L, 5);
                    float _z = (float)LuaAPI.lua_tonumber(L, 6);
                    
                    gen_to_be_invoked.moveMap( _nowmap, _nowmapid, _x, _y, _z );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_peopleJiaoHu(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Public gen_to_be_invoked = (Public)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.peopleJiaoHu(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_peopleJiaoHuClose(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Public gen_to_be_invoked = (Public)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.peopleJiaoHuClose(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_setChildObjOfCanvas(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Public gen_to_be_invoked = (Public)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string _type = LuaAPI.lua_tostring(L, 2);
                    
                    gen_to_be_invoked.setChildObjOfCanvas( _type );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_showLoadScene(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Public gen_to_be_invoked = (Public)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.showLoadScene(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_closeLoadScene(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Public gen_to_be_invoked = (Public)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.closeLoadScene(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_cameraPosInit(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Public gen_to_be_invoked = (Public)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    float _x = (float)LuaAPI.lua_tonumber(L, 2);
                    float _y = (float)LuaAPI.lua_tonumber(L, 3);
                    float _z = (float)LuaAPI.lua_tonumber(L, 4);
                    
                    gen_to_be_invoked.cameraPosInit( _x, _y, _z );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ShowXiTongChat_o(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Public gen_to_be_invoked = (Public)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string _note = LuaAPI.lua_tostring(L, 2);
                    
                    gen_to_be_invoked.ShowXiTongChat_o( _note );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_getType(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Public gen_to_be_invoked = (Public)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object _ob = translator.GetObject(L, 2, typeof(object));
                    
                        string gen_ret = gen_to_be_invoked.getType( _ob );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_instance(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    translator.Push(L, Public.instance);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_isGuide(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Public gen_to_be_invoked = (Public)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.isGuide);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_canvas(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Public gen_to_be_invoked = (Public)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.canvas);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_canvasLoad(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Public gen_to_be_invoked = (Public)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.canvasLoad);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_TextDrama(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Public gen_to_be_invoked = (Public)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.TextDrama);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_fightAnimation(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Public gen_to_be_invoked = (Public)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.fightAnimation);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_settlement(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Public gen_to_be_invoked = (Public)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.settlement);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_SaveMoldState(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Public gen_to_be_invoked = (Public)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.SaveMoldState);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Xend1(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Public gen_to_be_invoked = (Public)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.Xend1);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Xegde1(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Public gen_to_be_invoked = (Public)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.Xegde1);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Yend1(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Public gen_to_be_invoked = (Public)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.Yend1);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Yegde1(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Public gen_to_be_invoked = (Public)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.Yegde1);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Xend2(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Public gen_to_be_invoked = (Public)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.Xend2);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Xegde2(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Public gen_to_be_invoked = (Public)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.Xegde2);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Yend2(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Public gen_to_be_invoked = (Public)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.Yend2);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Yegde2(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Public gen_to_be_invoked = (Public)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.Yegde2);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_instance(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    Public.instance = (Public)translator.GetObject(L, 1, typeof(Public));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_isGuide(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Public gen_to_be_invoked = (Public)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.isGuide = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_canvas(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Public gen_to_be_invoked = (Public)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.canvas = (UnityEngine.GameObject)translator.GetObject(L, 2, typeof(UnityEngine.GameObject));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_canvasLoad(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Public gen_to_be_invoked = (Public)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.canvasLoad = (UnityEngine.GameObject)translator.GetObject(L, 2, typeof(UnityEngine.GameObject));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_TextDrama(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Public gen_to_be_invoked = (Public)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.TextDrama = (UnityEngine.GameObject)translator.GetObject(L, 2, typeof(UnityEngine.GameObject));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_fightAnimation(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Public gen_to_be_invoked = (Public)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.fightAnimation = (UnityEngine.GameObject)translator.GetObject(L, 2, typeof(UnityEngine.GameObject));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_settlement(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Public gen_to_be_invoked = (Public)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.settlement = (UnityEngine.GameObject)translator.GetObject(L, 2, typeof(UnityEngine.GameObject));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_SaveMoldState(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Public gen_to_be_invoked = (Public)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.SaveMoldState = (System.Collections.Generic.Dictionary<int, int>)translator.GetObject(L, 2, typeof(System.Collections.Generic.Dictionary<int, int>));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Xend1(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Public gen_to_be_invoked = (Public)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.Xend1 = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Xegde1(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Public gen_to_be_invoked = (Public)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.Xegde1 = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Yend1(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Public gen_to_be_invoked = (Public)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.Yend1 = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Yegde1(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Public gen_to_be_invoked = (Public)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.Yegde1 = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Xend2(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Public gen_to_be_invoked = (Public)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.Xend2 = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Xegde2(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Public gen_to_be_invoked = (Public)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.Xegde2 = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Yend2(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Public gen_to_be_invoked = (Public)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.Yend2 = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Yegde2(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Public gen_to_be_invoked = (Public)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.Yegde2 = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
