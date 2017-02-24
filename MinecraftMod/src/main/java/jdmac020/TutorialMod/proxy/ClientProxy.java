package jdmac020.TutorialMod.proxy;

import jdmac020.TutorialMod.init.TutorialBlocks;
import jdmac020.TutorialMod.init.TutorialFood;
import jdmac020.TutorialMod.init.TutorialItems;
import jdmac020.TutorialMod.init.TutorialTools;
import jdmac020.TutorialMod.init.TutorialWeapons;
import jdmac020.TutorialMod.init.crafting.TutorialRecipes;
import jdmac020.TutorialMod.init.crafting.TutorialSmelting;
import jdmac020.TutorialMod.init.worldgen.TutorialWorldGen;
import net.minecraft.item.Item;
import net.minecraftforge.fml.common.event.FMLInitializationEvent;
import net.minecraftforge.fml.common.event.FMLPostInitializationEvent;
import net.minecraftforge.fml.common.event.FMLPreInitializationEvent;
import net.minecraftforge.fml.common.registry.GameRegistry;

public class ClientProxy extends CommonProxy
{
	@Override
	public void preInit(FMLPreInitializationEvent event)
	{
		super.preInit(event);
		TutorialItems.init();
		TutorialFood.init();
		TutorialTools.init();
		TutorialSmelting.init();
		TutorialRecipes.init();
		TutorialWeapons.init();
	}
	
	@Override
	public void init(FMLInitializationEvent event)
	{
		super.init(event);
		TutorialItems.register();
		TutorialBlocks.registerRenders();
		TutorialFood.register();
		TutorialTools.register();
		TutorialWeapons.register();
		
		GameRegistry.registerWorldGenerator(new TutorialWorldGen(), 0);
	}
	
	@Override
	public void postInit(FMLPostInitializationEvent event)
	{
		super.postInit(event);
	}
	
}