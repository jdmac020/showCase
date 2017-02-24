package jdmac020.TutorialMod.init;

import net.minecraft.creativetab.CreativeTabs;
import net.minecraft.item.Item;

public class TutorialTabs 
{
	
	public static final CreativeTabs tabTutorialItems = new CreativeTabs("tabTutorialItems")
	{
		@Override
		public Item getTabIconItem() 
		{
			return TutorialItems.GOLD_COIN;
		}
	};
	
	public static final CreativeTabs tabTutorialBlocks = new CreativeTabs("tabTutorialBlocks")
	{
		@Override
		public Item getTabIconItem() 
		{
			return Item.getItemFromBlock(TutorialBlocks.RUBY_ORE);
		}
	};
	
	public static final CreativeTabs tabTutorialFood = new CreativeTabs("tabTutorialFood")	
	{
		
		@Override
		public Item getTabIconItem() 
		{
			return TutorialFood.BUTTER;
		}
	};
	

	public static final CreativeTabs tabTutorialTools = new CreativeTabs("tabTutorialTools")	
	{
		
		@Override
		public Item getTabIconItem() 
		{
			return TutorialTools.RUBY_PICKAXE;
		}
	};
	
	public static final CreativeTabs tabTutorialWeapons = new CreativeTabs("tabTutorialWeapons")	
	{
		
		@Override
		public Item getTabIconItem() 
		{
			return TutorialWeapons.RUBY_SWORD;
		}
	};
}
