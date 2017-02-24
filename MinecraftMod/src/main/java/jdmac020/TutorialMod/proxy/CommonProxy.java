package jdmac020.TutorialMod.proxy;

import jdmac020.TutorialMod.init.TutorialBlocks;
import jdmac020.TutorialMod.init.TutorialFood;
import jdmac020.TutorialMod.init.TutorialItems;
import jdmac020.TutorialMod.init.TutorialTools;
import jdmac020.TutorialMod.init.TutorialWeapons;
import jdmac020.TutorialMod.init.crafting.TutorialSmelting;
import net.minecraft.item.Item;
import net.minecraftforge.fml.common.event.FMLInitializationEvent;
import net.minecraftforge.fml.common.event.FMLPostInitializationEvent;
import net.minecraftforge.fml.common.event.FMLPreInitializationEvent;
import net.minecraftforge.fml.common.registry.GameRegistry;

public class CommonProxy 
{
	public void preInit(FMLPreInitializationEvent event)
	{
		TutorialBlocks.init();
		TutorialBlocks.register();
		
		TutorialItems.init();
		TutorialTools.init();
		TutorialFood.init();
		TutorialWeapons.init();
	}
	
	public void init(FMLInitializationEvent event)
	{
		TutorialItems.register();
	}
	
	public void postInit(FMLPostInitializationEvent event)
	{
		
	}
	
	public void registerItemSided(Item item)
	{
		
	}
}